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
    public interface IBasketDetail : IBaseRepos<BasketDetail>
    {

        public BasketDetailDTO GetAmount(int Amount);//sepet detaylarını alır. seçilmek istenenleri!
        public GeneralResponse AddToBasket(int basketId, int productId, int amount);
        


    }
}
