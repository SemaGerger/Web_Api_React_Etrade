using Mvc_Api_Etrade.Core;
using Mvc_Api_Etrade.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Repository.Abstract
{
    public interface ICategory : IBaseRepos<Category>
    {
        public void AddDefaultCategory();
    }
}
