using Microsoft.EntityFrameworkCore;
using Mvc_Api_Etrade.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mvc_Api_Etrade.Core
{
    public interface IBaseRepos<T> where T : class
    {
        public DbSet<T> Set();

        List<T> List();
        public T Find(int Id);
        public T Find(string Id);//email string olduğu için bunu oluşturdum.iki tane method ismi ile overlood yaptım.
        GeneralResponse Add(T entity);
        GeneralResponse Update(T entity);
        GeneralResponse Delete(T entity);


    }
}
