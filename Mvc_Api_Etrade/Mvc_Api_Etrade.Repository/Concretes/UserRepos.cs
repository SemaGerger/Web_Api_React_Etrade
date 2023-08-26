using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.Dal;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Repository.Abstract;
using Mvc_Api_Etrade.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Repository.Concretes
{
    public class UserRepos : BaseRepos<User>, IUserRepos
    {

        GeneralResponse _generalResponse;
        PerContext _context;
      
      
        public UserRepos(PerContext context, GeneralResponse response ) : base(context, response)
        {
            _generalResponse = response;
         
          _context = context;
        }
        public IEnumerable<User> GetUserList()
        {
            return _context.Set<User>().ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public bool Register(User registerUser)
        {
            User user = Find(registerUser.Email);
            if (user == null) //user'i User'den ya newlemek gerekioyrdu ya da programa yazmak gerekiyordu. yazdım..
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public GeneralResponse Login(LoginDTO login)
        {
            User user = Find(login.Email);
            if (user == null)
            {
                _generalResponse.Status = false;
                _generalResponse.Msg = "Email/Password is incorrect or missing.";
            }
            else
            {
                bool verified = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
                if (verified)
                {
                    _generalResponse.Status = true;
                    _generalResponse.Msg = "Login Successful";
                }
                else
                {
                    _generalResponse.Status = false;
                    _generalResponse.Msg = "Email/Password is incorrect or missing.";
                }
            }
            return _generalResponse;
        }

        public void AddDefaultUser()
        {
            if (_context.Users.Any())
            {
                return;
            }

            User defaultUser = new User
            {
                Name = "quest",
                Surname = "questt",
                Email = "guest@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("defaultpassword"),
                Role = "user"
            };

            _context.Users.Add(defaultUser);
            _context.SaveChanges();
        }
    }
}
