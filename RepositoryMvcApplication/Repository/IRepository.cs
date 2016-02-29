using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        long Count();
        void Save();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
    }
}
