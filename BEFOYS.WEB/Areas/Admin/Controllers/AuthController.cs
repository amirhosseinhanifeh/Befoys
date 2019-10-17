using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Permission;
using BEFOYS.DataLayer.ViewModels.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly ServiceContext _context;

        public AuthController(ServiceContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<BaseViewModel<ViewSupplierInfo>>> Me()
        {
            try
            {
                var user = User.Identity.UserID();
                var Result = await _context.Tbl_Login.Where(x => x.Login_ID == user).Select(x => new ViewSupplierInfo
                {
                    FirstName = x.Login_FirstName,
                    LastName = x.Login_LastName,
                    Email = x.Login_Email,
                    IsBan = x.Login_IsBan.GetValueOrDefault(),
                    Permissions = x.AccountControl.PanelType.PanelTypePermissions.Select(y => new ViewPermission(y.Permission)).ToList()

                }).FirstOrDefaultAsync();

                return new BaseViewModel<ViewSupplierInfo> { Value = Result, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewSupplierInfo> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
    }
}