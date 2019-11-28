using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Account;
using BEFOYS.DataLayer.ViewModels.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly ServiceContext _context;

        public AuthController(ServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<BaseViewModel<ViewAccountInfo>>> Me()
        {
            try
            {
                var user = User.Identity.UserID();
                var Result = await _context.TblLogin.Where(x => x.LoginId == user).Select(x => new ViewAccountInfo
                {
                    FirstName = x.LoginFirstName,
                    LastName = x.LoginLastName,
                    Email = x.LoginEmail,
                    IsBan = x.LoginIsBan,
                    
                }).FirstOrDefaultAsync();

                return new BaseViewModel<ViewAccountInfo> { Value = Result, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewAccountInfo> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
    }
}