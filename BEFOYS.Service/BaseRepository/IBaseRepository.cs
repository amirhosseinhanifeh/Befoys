using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEFOYS.Service.BaseRepository
{
    public interface IBaseRepository<T>: IDisposable
    {
        void Delete(object Id);
        Task<List<T>> GetAll();
        Task<T> GetById(object Id);
        void Insert(T model);
        Task<int> Save();
    }
}
