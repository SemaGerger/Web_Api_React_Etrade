using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Entity
{
    public class Product : BaseClass
    {

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VAT { get; set; }
        [ForeignKey("CategoryId")]
        public Category ?Categories { get; set; } //soru işareti null olabilir demek için konuldu
        [ForeignKey("SupplierId")]
        public Supplier ?Suppliers { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<BasketDetail> BasketDetail { get; set; } //yeni
        



    }
}
