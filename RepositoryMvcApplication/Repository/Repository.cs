using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using RepositoryMvcApplication.Entities;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
{
        private DataTestEntities m_Context = null;
        DbSet<T> m_DbSet;

        public Repository(DataTestEntities context)
        {
            m_Context = context;
            m_DbSet = m_Context.Set<T>();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }
                return m_DbSet.AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
                return m_DbSet.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
                m_DbSet.Add(entity);
        }

        public void Save()
        {
            m_Context.SaveChanges();
        }

        public void Update(T entity)
        {
            m_DbSet.Attach(entity);
            ((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            m_DbSet.Remove(entity);
        }

        public long Count()
        {
            return m_DbSet.Count();
        }
}
}
