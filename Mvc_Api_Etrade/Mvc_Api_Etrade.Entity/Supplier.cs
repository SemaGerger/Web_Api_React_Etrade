using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Entity
{
    public class Supplier : BaseClass
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public string Street { get; set; }

        public string Provience { get; set; }
        public string City { get; set; }
        public int No { get; set; }
        public int TaxNo { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
