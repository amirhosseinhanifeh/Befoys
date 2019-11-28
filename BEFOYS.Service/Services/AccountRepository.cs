using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.Service.BaseRepository;

namespace BEFOYS.Service.Service
{
    public class AccountRepository : BaseRepository<TblLogin>
    {
        private ServiceContext _context;
        public AccountRepository(ServiceContext context):base(context)
        {
            _context = context;
        }

    }
}
