using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Repository.Concretes;
using Mvc_Api_Etrade.Response;
using Mvc_Api_Etrade.UoW;

//deneme
namespace Mvc_Api_Etrade.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUoW _uow;
        UserResponse _response;
        GeneralResponse _general;
        public UserController(IUoW uow, UserResponse response, GeneralResponse general)
        {
            _uow = uow;
            _response = response;
            _general = general;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUserList()
        {
            var users = _uow._userRepos.GetUserList(); // Kullanıcı listesini almak için uygun metodu çağırın

            if (users != null && users.Any())
            {
                return Ok(users);
            }
            else
            {
                var response = new UserResponse
                {
                    Msg = "No users found"
                };
                return NotFound(response); // Kullanıcı bulunamadığında NotFound yanıtı dön
            }
        }

        [HttpGet]
        public ActionResult<User> GetUserByEmail(string email)
        {
            var user = _uow._userRepos.GetUserByEmail(email);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                var response = new UserResponse
                {
                    Msg = "User not found"
                };
                return NotFound(response);
            }
        }

        [HttpPost]
        public UserResponse Register(User user)
        {
            bool value = _uow._userRepos.Register(user);
            if (value)
            {
                user.Role = "user";
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                _uow._userRepos.Add(user);
                _uow.Commit();
                _response.Msg = "Register Successful";
            }
            else _response.Msg = "Already registered!";
            return _response;
        }

        [HttpPut]
        public GeneralResponse Login(LoginDTO login)
        {
            GeneralResponse rep = _uow._userRepos.Login(login);
            
            return rep;
        }

    }

}


