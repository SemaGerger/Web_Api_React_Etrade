using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.DTO
{
    public class BasketMasterDTO
    {
        public string Email { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }

        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}
