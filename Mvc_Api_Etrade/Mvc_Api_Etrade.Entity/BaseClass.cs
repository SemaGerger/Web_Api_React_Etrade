using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Entity
{
    public class BaseClass
    {
        [Key]
        public int Id { get; set; }
        public string ?Description { get; set; }

    }
}
