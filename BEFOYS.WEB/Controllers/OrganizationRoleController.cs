using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Organization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganizationRoleController : ControllerBase,IDisposable
    {
        private readonly ServiceContext _context;

        public OrganizationRoleController(ServiceContext context)
        {
            _context = context;
        }
        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Post([FromBody]ViewOrganizationRole model)
        {
            try
            {
                var user = await _context.TblEmployee.FirstOrDefaultAsync(x=>x.EmployeeLoginId==User.Identity.UserID());
                TblOrganizationRole role = new TblOrganizationRole()
                {
                    OrCanCreateRole=model.OrCanCreateRole,
                    OrDisplay=model.OrDisplay,
                    OrOrganizationId=user.EmployeeOrganizationId,
                    OrOrid=model.OrOrid.GetValueOrDefault()
                };
                await _context.TblOrganizationRole.AddAsync(role);
                await _context.SaveChangesAsync();
                return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOrganizationRole>>> Get()
        {
            return await _context.TblOrganizationRole.ToListAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}