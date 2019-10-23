using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Supplier;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class SupplierController : ControllerBase
    {
        private ServiceContext _context;

        public SupplierController(ServiceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<BaseViewModel<List<Tbl_Supplier>>> Get()
        {
            try
            {

                return new BaseViewModel<List<Tbl_Supplier>> { Value = await _context.Tbl_Supplier.ToListAsync(), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<List<Tbl_Supplier>>
                {
                    Value = null,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }


        [HttpPost]
        public async Task<BaseViewModel<Tbl_Supplier>> Approved([FromBody] string ID)
        {
            try
            {
                Guid UserID = ID.ToGuid();
                var user =await _context.Tbl_Login.FirstOrDefaultAsync(x => x.Login_GUID == UserID);
                user.Login_IsRegister = true;
                await _context.SaveChangesAsync();
                return new BaseViewModel<Tbl_Supplier> { Value = null, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_Supplier>
                {
                    Value = null,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }

    }
}