using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.DTO;
using Mvc_Api_Etrade.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Repository.Abstract
{
    public interface IProduct : IBaseRepos<Product>
    {

        public List<ProductsDTO> GetProducts();
        public void AddDefaultProducts();
      


    }
}
