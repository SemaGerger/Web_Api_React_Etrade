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
    public class BasketDetailRepos : BaseRepos<BasketDetail>, IBasketDetail
    {
        BasketDetailDTO _bd;
        BasketMasterDTO _bmd;
        
        

        public BasketDetailRepos(PerContext context, GeneralResponse response, BasketDetailDTO bd, BasketMasterDTO bmd)  : base(context, response)
        {
            _bd = bd;
            _bmd = bmd;
           
        }

        public BasketDetailDTO GetAmount(int Amount)//sepet detaylarını alır. seçilmek istenenleri!
        {

            _bd.Amount = Amount;
          

            return _bd;
        }


        public GeneralResponse AddToBasket(int basketId, int productId, int amount)
        {
            try
            {
                BasketDetail basketDetail = new BasketDetail
                {
                    BasketId = basketId,
                    ProductId = productId,
                    Amount = amount,

                    UnitPrice = _context.Set<Product>().Find(productId)?.UnitPrice ?? 0,
                    PhotoUrl = _context.Set<Product>().Find(productId)?.PhotoUrl ?? string.Empty,
                    Description = _context.Set<Product>().Find(productId)?.Description ?? string.Empty,
                    Total = _bmd.Amount * _bmd.UnitPrice,
                    OrderDate = DateTime.Now, // DateTime.UtcNow
                };

                Add(basketDetail);
                _response.Msg = "Added to basket.";
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Msg = $"Could not add to basket. Error: {ex.Message}";
            }

            return _response;
        }
    
    }
}






