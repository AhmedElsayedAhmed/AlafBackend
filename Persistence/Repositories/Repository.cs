using Framework.Core;
using Framework.Core.Model;
using Framework.Core.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly aalafContext _context;
        private DbSet<T> _entities;
        public IQueryable<T> Table => Entities;
        public Repository(aalafContext context)
        {
            _context = context;
            //if (_context.Database.EnsureCreated())
            //    _context.Database.Migrate();
        }


        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }
                return _entities;
            }
        }

 

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.AddAsync(entity);
                // _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

        public void Insert(IList<T> entities)
        {
            try
            {
                if (entities == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.AddRangeAsync(entities);
                // _context.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }


        public void Update(T updated)
        {
            var ce = _context.Entry<T>(updated);
            if (ce != null)
            {
                if (ce.State == EntityState.Detached)
                {
                    _entities.Attach(updated);
                }
                ce.State = EntityState.Modified;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.Remove(entity);
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

     
        protected IQueryable<T> QEntities(bool track = true)
        {
            return track ? Entities : Entities.AsNoTracking();
        }

        public T Single(Expression<Func<T, bool>> predicate, bool track = true)
        {
            return QEntities(track).SingleOrDefault(predicate);
        }
        public ICollection<T> Where(Expression<Func<T, bool>> predicate, bool track = true)
        {
            return QEntities(track).Where(predicate).ToList();
        }
        //public async Task<T> GetById(object id)
        //{
        //    return await Entities.FindAsync(id);
        //}

        public IQueryable<T> GetAll()
        {
            return Entities ;
        }


    }
}