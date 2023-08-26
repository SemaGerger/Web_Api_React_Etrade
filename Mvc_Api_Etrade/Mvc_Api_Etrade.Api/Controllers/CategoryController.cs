using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Response;
using Mvc_Api_Etrade.UoW;

namespace Mvc_Api_Etrade.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IUoW _uow;
        public CategoryController(IUoW uoW)
        {
            _uow = uoW;
        }
        [HttpGet]
        public List<Category> List()
        {
            return _uow._categoryRepos.List();
        }
        [HttpPost]
        public GeneralResponse Create(Category category)
        {
            var response = _uow._categoryRepos.Add(category);
            _uow.Commit();
            return response;
        }
        [HttpPut]
        public GeneralResponse Update(Category category)
        {
            var response = _uow._categoryRepos.Update(category);
            _uow.Commit();
            return response;
        }
        [HttpDelete]
        public GeneralResponse Delete(Category category)
        {
            var response = _uow._categoryRepos.Delete(category);
            _uow.Commit();
            return response;
        }
    }
}
