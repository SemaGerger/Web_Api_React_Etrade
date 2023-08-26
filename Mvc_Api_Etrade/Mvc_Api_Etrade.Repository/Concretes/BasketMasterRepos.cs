using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.Dal;
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
    public class BasketMasterRepos : BaseRepos<BasketMaster>, IBasketMaster
    {
        
        public BasketMasterRepos(PerContext context, GeneralResponse response) : base(context, response)
        {
            
        }

        public int CheckOrder(string userId)
        {
            BasketMaster bm = Set().FirstOrDefault(x => x.UserId == userId && x.Status == 2);
            return bm?.BasketId ?? 0;
        }

        public void AddDefaultBasket()
        {
            if (_context.Baskets.Any())
            {
                return;
            }

            //İlk açılışta sql'e kaydedilip görünecek olan defoult
            BasketMaster defoultBasket = new BasketMaster
            {
            UserId = "guest@example.com",
            OrderDate = DateTime.Now,
            Status = 2
            };
            _context.Baskets.Add(defoultBasket);
            _context.SaveChanges();
        }
    }
}




