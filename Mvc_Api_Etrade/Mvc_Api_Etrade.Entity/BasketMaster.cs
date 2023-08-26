using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Entity
{
    public class BasketMaster
    {
        public BasketMaster()
        {
            BasketDetail = new HashSet<BasketDetail>();
        }
        [Key]
        public int BasketId { get; set; }
        public string UserId { get; set; }
       

      
        public DateTime ?OrderDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public User Users { get; set; } 

        public int Status { get; set; }
        public ICollection<BasketDetail> BasketDetail { get; set; }

    }
}
