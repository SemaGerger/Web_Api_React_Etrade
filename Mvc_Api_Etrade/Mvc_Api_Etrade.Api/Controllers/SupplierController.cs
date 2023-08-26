using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Response;
using Mvc_Api_Etrade.UoW;

namespace Mvc_Api_Etrade.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        IUoW _uow;
        GeneralResponse _generalResponse;
        public SupplierController(IUoW uow, GeneralResponse generalResponse)
        {
            _uow = uow;
            _generalResponse = generalResponse;


        }
        [HttpGet]
        public List<Supplier> List()
        {
            return _uow._supplierRepos.List();

        }
        [HttpPost]
        public GeneralResponse Create(Supplier supplier)
        {
            var response = _uow._supplierRepos.Add(supplier);
            _uow.Commit();
            return response;
        }
        [HttpPut]
        public GeneralResponse Update(Supplier supplier)
        {
            var response = _uow._supplierRepos.Update(supplier);
            _uow.Commit();
            return response;

        }
        [HttpDelete]
        public GeneralResponse Delete(Supplier supplier)
        {
            var response = _uow._supplierRepos.Delete(supplier);
            _uow.Commit();
            return response;

        }
    }
}
