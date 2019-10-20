using BEFOYS.DataLayer.ServiceContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFOYS.Service.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T: class
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

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
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
