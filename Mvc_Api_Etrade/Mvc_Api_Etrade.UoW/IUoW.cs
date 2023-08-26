using Mvc_Api_Etrade.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.UoW
{
    public interface IUoW
    {
        public IBasketMaster _basketMasterRepos { get; }
        public IBasketDetail _basketDetailRepos { get; }
        public ICategory _categoryRepos { get; }
        public IProduct _productRepos { get; }
        public IUserRepos _userRepos { get; }
        public ISupplier _supplierRepos { get; }
        public void Commit();
    }
}
