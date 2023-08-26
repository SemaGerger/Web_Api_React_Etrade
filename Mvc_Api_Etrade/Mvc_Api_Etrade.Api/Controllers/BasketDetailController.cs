using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Repository.Abstract;
using Mvc_Api_Etrade.UoW;

namespace Mvc_Api_Etrade.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketDetailController : ControllerBase
    {
        IUoW _uow;
        BasketDetail _bd;
       
     
        public BasketDetailController(IUoW uow, BasketDetail bd)
        {
            _uow = uow;
            _bd = bd;
            
        }


        [HttpPost]
        public IActionResult Add(int basketId, int productId, [FromBody] BasketDetailDTO dto)
        {

            try
            {
                // bu if'ler doğrulama kodlarıdır
                if (productId <= 0)
                {
                    return BadRequest("Invalid productId.");
                }

                if (basketId <= 0)
                {
                    return BadRequest("Invalid basketId.");
                }


                if (dto.Amount <= 0)
                {
                    return BadRequest("Invalid amount.");
                }



                _uow._basketDetailRepos.AddToBasket(basketId, productId, dto.Amount);
                _uow.Commit();

                return Ok(new { Message = "Product added to basket." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding the product to the basket: {ex.Message}");
            }
        }



        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var basketDetails = _uow._basketDetailRepos.List();
                return Ok(basketDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Remove(int basketId, int productId)
        {
            try
            {
                var basketDetail = _uow._basketDetailRepos.Set().FirstOrDefault(bd => bd.BasketId == basketId && bd.ProductId == productId);

                if (basketDetail == null)
                {
                    return NotFound("Basket detail not found.");
                }

                _uow._basketDetailRepos.Delete(basketDetail);
                _uow.Commit();

                // Check if there are any remaining items in the basket
                var remainingItems = _uow._basketDetailRepos.Set().Any(bd => bd.BasketId == basketId);
                if (!remainingItems)
                {
                    var basket = _uow._basketMasterRepos.Set().FirstOrDefault(bm => bm.BasketId == basketId);
                    if (basket != null)
                    {
                        basket.Status = 0;
                        _uow._basketMasterRepos.Update(basket);
                        _uow.Commit();
                    }
                }

                return Ok(new { Message = "Product removed from basket." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

