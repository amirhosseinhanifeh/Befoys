using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Register;
using BEFOYS.Service.BaseRepository;
using BEFOYS.Service.IServices;
using System.Linq;

namespace BEFOYS.Service.Services
{
    public class LoginService : BaseRepository<TblLogin>, ILoginService
    {
        private readonly ServiceContext _context;
        public LoginService(ServiceContext context) : base(context)
        {
            _context = context;
        }

        public bool Check(ViewBaseRegister model)
        {
            return !_context.TblLogin.Any(x => x.LoginMobile == model.Mobile) && !_context.TblLogin.Any(x => x.LoginEmail == model.Email);
        }
    }
}
