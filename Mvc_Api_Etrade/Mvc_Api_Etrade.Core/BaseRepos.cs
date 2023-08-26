using Microsoft.EntityFrameworkCore;
using Mvc_Api_Etrade.Dal;
using Mvc_Api_Etrade.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc_Api_Etrade.Core
{
    public class BaseRepos<T> : IBaseRepos<T> where T : class
    {
        public PerContext _context { get; }
        public GeneralResponse _response { get; }
        string tableName = typeof(T).Name;

        public BaseRepos(PerContext context, GeneralResponse generalResponse)
        {
            _context = context;
            _response = generalResponse;
        }
        public DbSet<T> Set()
        {
            return _context.Set<T>();
        }

        public GeneralResponse Add(T entity)
        {
            try
            {
                Set().Add(entity);
                _response.Status = true;
                _response.Msg = $"Added to {tableName}";
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Msg = $"{tableName}  table could not be completed. Error: {ex.Message}";

            }
            return _response;
        }

        public GeneralResponse Delete(T entity)
        {
            try
            {
                Set().Remove(entity);
                _response.Status = true;
                _response.Msg = $"Deleted from {tableName}";
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Msg = $"{tableName} table could not be completed. Error: {ex.Message}";

            }
            return _response;
        }
        public GeneralResponse Update(T entity)
        {
            try
            {
                Set().Update(entity);
                _response.Status = true;
                _response.Msg = $"Update from {tableName}";
            }
            catch (Exception ex)
            {
                _response.Status = false;
                _response.Msg = $"{tableName} table could not be completed. Error: {ex.Message} .";

            }
            return _response;
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }
        public T Find(string Id)
        {
            return Set().Find(Id);
        }

        public List<T> List()
        {
            return Set().ToList();
        }



     


    }
}
