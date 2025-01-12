using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Func<T, bool> predicate);
        int Insert(T entity);
        int Update(T entity);
        int Delete(int id);
        int GetTotalCount(Func<T, bool>? predicate = null);
    }
}
