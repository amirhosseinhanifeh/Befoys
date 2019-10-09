using BEFOYS.DataLayer.Entity;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.Service.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BEFOYS.Service.Service
{
    public class AccountRepository : BaseRepository<Tbl_Login>
    {
        private ServiceContext _context;
        public AccountRepository(ServiceContext context):base(context)
        {
            _context = context;
        }

    }
}
