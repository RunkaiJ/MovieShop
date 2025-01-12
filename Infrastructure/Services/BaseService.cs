using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;

namespace Infrastructure.Services
{
    public class BaseService<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository) { 
            _repository = repository;
        }
        public int Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public int GetTotalCount(Func<T, bool>? predicate = null)
        {
            return _repository.GetTotalCount(predicate);
        }

        public int Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            return _repository.Search(predicate);
        }

        public int Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
