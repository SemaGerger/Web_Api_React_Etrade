using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using Mvc_Api_Etrade.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Repository.Abstract
{
    public interface IUserRepos : IBaseRepos<User>
    {
        public bool Register(User registerUser);
        public GeneralResponse Login(LoginDTO login);

        public IEnumerable<User> GetUserList();

        public User GetUserByEmail(string email);

        
        public void AddDefaultUser();


    }
}
