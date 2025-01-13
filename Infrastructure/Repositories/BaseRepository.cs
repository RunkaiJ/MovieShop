using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _context;

        public BaseRepository(MovieShopDbContext context) {
            _context = context;
        }
        public int Delete(int id)
        {
            T entity = GetById(id);
            if (entity != null) { 
                _context.Set<T>().Remove(entity);
            }
            return _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int GetTotalCount(Func<T, bool>? predicate = null)
        {
            if (predicate == null)
            {
                return _context.Set<T>().Count();
            }
            return _context.Set<T>().Count(predicate);
        }

        public int Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            return _context.Set<T>().ToList().Where(predicate);
        }

        public int Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }
    }
}
