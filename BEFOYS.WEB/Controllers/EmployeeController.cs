using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.AppUser;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public EmployeeController(ServiceContext context)
        {
            _context = context;
        }
        /// <summary>
        /// برای ذخیره داخل دیتابیس
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public async Task<BaseViewModel<bool>> Post([FromBody]ViewEmployee model)
        {
            try
            {
                var user = User.Identity.UserID();
                var organization = await _context.TblEmployee.FirstOrDefaultAsync(x=>x.EmployeeLoginId==user);
                TblEmployee ci = new TblEmployee()
                {
                    EmployeeIsAgent=model.EmployeeIsAgent,
                    EmployeeWalletSize=model.EmployeeWalletSize,
                    EmployeeOrid=model.EmployeeOrid,
                    EmployeeOrganizationId=organization.EmployeeOrganizationId
                };
                await _context.TblEmployee.AddAsync(ci);
                await _context.SaveChangesAsync();
                return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmployee>>> Get()
        {

            return await _context.TblEmployee.ToListAsync();
        }
        [HttpGet("{OrganizationID}")]
        public async Task<ActionResult<IEnumerable<TblEmployee>>> Get(int OrganizationID)
        {
            return await _context.TblEmployee.Where(x=>x.EmployeeOrganizationId==OrganizationID).ToListAsync();
        }
        //[HttpGet("{Province_ID}")]
        //public async Task<ActionResult<IEnumerable<TblEmployee>>> Get(int? Province_ID = null)
        //{
        //    return await _context.TblEmployee.Where(x => x.CityProvinceId == Province_ID).ToListAsync();
        //}
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Delete(int? id)
        {
            try
            {
                var data = await _context.TblEmployee.FindAsync(id);
                if (data != null)
                {
                    _context.TblEmployee.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<bool> { Value = true, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}