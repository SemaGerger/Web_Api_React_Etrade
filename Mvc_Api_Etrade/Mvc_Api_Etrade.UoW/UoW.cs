using Mvc_Api_Etrade.Dal;
using Mvc_Api_Etrade.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.UoW
{
    public class UoW : IUoW
    {
        public UoW(PerContext context, IBasketDetail basketDetailRepos, IBasketMaster basketMasterRepos, IUserRepos userRepos, ISupplier supplierRepos, ICategory categoryRepos, IProduct productRepos)
        {
            Context = context;
            _basketDetailRepos = basketDetailRepos;
            _basketMasterRepos = basketMasterRepos;
            _categoryRepos = categoryRepos;
            _productRepos = productRepos;
            _supplierRepos = supplierRepos;
            _userRepos = userRepos;
        }
        private readonly PerContext Context;
        public IBasketMaster _basketMasterRepos { get; }
        public IBasketDetail _basketDetailRepos { get; }
        public ICategory _categoryRepos { get; }
        public IUserRepos _userRepos { get; }
        public IProduct _productRepos { get; }
        public ISupplier _supplierRepos { get; }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
