using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Repository.Abstract;
using Mvc_Api_Etrade.Response;
using Mvc_Api_Etrade.UoW;

namespace Mvc_Api_Etrade.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketMasterController : ControllerBase
    {
        IUoW _uow;
        BasketMaster _bm;
        private IBasketDetail _basketDetailRepos;
        public BasketMasterController(IUoW uow, BasketMaster bm, IBasketDetail basketDetailRepos)
        {
            _uow = uow;
            _bm = bm;
            _basketDetailRepos = basketDetailRepos;
        }
        [HttpGet]
        public IActionResult CheckOrder(string userId)
        {
            try
            {
                int basketId = _uow._basketMasterRepos.CheckOrder(userId);

                if (basketId == 0)
                {
                    BasketMaster bm = new BasketMaster
                    {
                        Status = 2,
                        OrderDate = DateTime.Now,
                        UserId = userId
                    };

                    _uow._basketMasterRepos.Add(bm);
                    _uow.Commit();

                    return Ok(new { Message = "Basket created and added to basket." });
                }
                else
                {
                    return Ok(new { Message = "Basket already exists." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}







