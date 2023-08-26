using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.DTO
{
    public class ProductsDTO
    {
        public int Id { get; set; }
     
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string SupplierName { get; set; }
        public string PhotoUrl { get; set; }
    }
}
