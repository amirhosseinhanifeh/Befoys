using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Register;
using BEFOYS.Service.BaseRepository;
using BEFOYS.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BEFOYS.Service.Services
{
    public class LoginService : BaseRepository<Tbl_Login>, ILoginService
    {
        private readonly ServiceContext _context;
        public LoginService(ServiceContext context) : base(context)
        {
            _context = context;
        }

        public bool Check(ViewBaseRegister model)
        {
            return !_context.Tbl_Login.Any(x => x.Login_Mobile == model.Mobile) && !_context.Tbl_Login.Any(x => x.Login_Email == model.Email);
        }
    }
}
