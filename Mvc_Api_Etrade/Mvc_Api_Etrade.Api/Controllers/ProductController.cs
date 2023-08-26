using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Response;
using Mvc_Api_Etrade.UoW;

namespace Mvc_Api_Etrade.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IUoW _uow;
        public ProductController(IUoW uow)
        {
            _uow = uow;
        }
        [HttpGet]
       
        public List<ProductsDTO> List()
        {
            return _uow._productRepos.GetProducts();

        }
        [HttpPost]
        public GeneralResponse Create(Product p)
        {
            var response = _uow._productRepos.Add(p);
            _uow.Commit();
            return response;
        }

        [HttpPut]
        public GeneralResponse Update(Product product)
        {
            var response = _uow._productRepos.Update(product);
            _uow.Commit();
            return response;
        }
        [HttpDelete]
        public GeneralResponse Delete(Product product)
        {
            var response = _uow._productRepos.Delete(product);
            _uow.Commit();
            return response;
        }

    }
}
