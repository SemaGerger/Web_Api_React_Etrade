using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Mvc_Api_Etrade.Entity
{
    public class BasketDetail
    {
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }

        public string PhotoUrl { get; set; }
        public string Description { get; set; }

        [ForeignKey("BasketId")]
        public BasketMaster BasketMaster { get; set; }

        public Product Products { get; set; }// yeni
        public decimal Total { get; set; }
        public DateTime ?OrderDate { get; set; }
        


    }
}
