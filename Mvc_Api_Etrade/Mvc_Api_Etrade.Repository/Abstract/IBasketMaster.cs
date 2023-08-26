using Microsoft.EntityFrameworkCore;
using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Repository.Abstract
{
    public interface IBasketMaster : IBaseRepos<BasketMaster>
    {
        public int CheckOrder(string userId);
 
        public void AddDefaultBasket();


    }
}
