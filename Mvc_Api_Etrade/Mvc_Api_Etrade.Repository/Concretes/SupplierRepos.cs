using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.Dal;
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
    
    public class SupplierRepos : BaseRepos<Supplier>, ISupplier
    {
        Supplier _supplier;
        public SupplierRepos(PerContext context, GeneralResponse response, Supplier supplier) : base(context, response)
        {
            _supplier = supplier;
        }
        public void AddDefaultSupplier()
        {
            if (_context.Suppliers.Any())
            {
                return;
            }

            //İlk açılışta sql'e kaydedilip görülecek olan defoult
            _supplier.Street = "Sermit";
            _supplier.Provience = "İstanbul";
            _supplier.City = "İstanbul";
            _supplier.No = 102;
            _supplier.TaxNo = 236472189;
            _supplier.Description = "Sanat Art";

            _context.Suppliers.Add(_supplier);
            _context.SaveChanges();
        }
    }
}
