using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillsManager.Repository.Repositories
{
    public class BaseInstanceRepository<T> : IBaseInstanceRepository<T> where T : class
    {


        protected readonly EmployeeSkillsDBContext db;

        internal DbSet<T> _dbSet;
        public BaseInstanceRepository(EmployeeSkillsDBContext _db)
        {
            db = _db;
            _dbSet = _db.Set<T>();
        }



        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _dbSet.AsNoTracking();
            return query;
        }


        public IEnumerable<T> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<T> AllInclude
        (params Expression<Func<T, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public IEnumerable<T> FindByInclude
          (Expression<Func<T, bool>> predicate,
          params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<T> results = query.Where(predicate).ToList();
            return results;
        }

        private IQueryable<T> GetAllIncluding
        (params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _dbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> results = _dbSet.AsNoTracking()
              .Where(predicate).ToList();
            return results;
        }

        public T FindByKey(int id)
        {
            Expression<Func<T, bool>> lambda = Utilities.BuildLambdaForFindByKey<T>(id);
            return _dbSet.AsNoTracking().SingleOrDefault(lambda);
        }

        public void InsertOrUpdate(T obj)
        {
            if (!_dbSet.Local.Contains(obj))
            {
                _dbSet.Attach(obj);
            }
            _dbSet.Add(obj);
            if (_dbSet != null)
                ContextHelpers.ApplyStateChanges(db);
        }

        public void Delete(T obj)
        {
            if (!_dbSet.Local.Contains(obj))
            {
                _dbSet.Attach(obj);
            }
            _dbSet.Remove(obj);

            if (_dbSet != null)
                ContextHelpers.ApplyStateChanges(db);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
