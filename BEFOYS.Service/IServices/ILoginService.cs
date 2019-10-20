using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.ViewModels.Register;
using BEFOYS.Service.BaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEFOYS.Service.IServices
{
    public interface ILoginService : IBaseRepository<Tbl_Login>
    {
        bool Check(ViewBaseRegister model);
    }
}
