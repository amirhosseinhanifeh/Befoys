using BEFOYS.DataLayer.Entity.Role;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.Service.BaseRepository;
using BEFOYS.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BEFOYS.Service.Services
{
    public class BaseRoleService : BaseRepository<Tbl_BaseRole>, IBaseRoleService
    {
        public BaseRoleService(ServiceContext context) : base(context)
        {
        }

    }
}
