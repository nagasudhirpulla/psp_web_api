using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSPDataFetchLayer.Repos
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> List { get; }
        Task<List<T>> ListAsync();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
    }
}
