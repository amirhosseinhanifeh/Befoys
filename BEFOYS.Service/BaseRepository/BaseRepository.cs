using BEFOYS.DataLayer.ServiceContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEFOYS.Service.BaseRepository
{
    public class BaseRepository<T> where T : class
    {
        private ServiceContext _context;
        public BaseRepository(ServiceContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }
        public void Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(object Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public void Insert(T model)
        {
            _context.AddAsync(model);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
