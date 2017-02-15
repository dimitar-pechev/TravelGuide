using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TravelGuide.Data.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filterExpression);
              
        void Add(T entity);
        
        void Delete(T entity);
    }
}
