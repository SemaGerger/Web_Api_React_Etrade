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
    public class CategoryRepos : BaseRepos<Category>, ICategory
    {

        public CategoryRepos(PerContext context, GeneralResponse response) : base(context, response)
        {

        }
        public void AddDefaultCategory()
        {
            if (_context.Categories.Any())
            {
                return;
            }

            //İlk açılışta sql'e kaydedilip görülecek olan defoult
            Category defoultCategory = new Category
            {
                Description = "Tablo"

            };


            _context.Categories.Add(defoultCategory);
            _context.SaveChanges();
        }
    }
}

