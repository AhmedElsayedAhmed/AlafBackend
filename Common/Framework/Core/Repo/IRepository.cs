using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Core.Repo
{
    public interface IRepository<T> where T : class
    {
      

        T Single(Expression<Func<T, bool>> predicate, bool track = true);

        T GetById(object id);

        void Insert(T entity);
        void Insert(IList<T> entities);
        void Update(T entity);

        void Delete(T entity);
        IQueryable<T> GetAll();

        IQueryable<T> Table { get; }
        ICollection<T> Where(Expression<Func<T, bool>> predicate, bool track = true);
    }
}