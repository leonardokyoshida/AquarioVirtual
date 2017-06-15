using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AquarioVirtual.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        T Add(T obj);
        T GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetFilter(string filter);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        void Remove(T obj);

        
    }
}
