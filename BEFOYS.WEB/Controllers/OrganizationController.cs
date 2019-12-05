using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganizationController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public OrganizationController(ServiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblOrganization>>> Get()
        {
            return await _context.TblOrganization.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> UpdateStatus([FromQuery]int Id,bool IsAccept)
        {

            try
            {
                var info = await _context.TblOrganizationInformation.FindAsync(Id);
                info.OiIsAccept = IsAccept;
                await _context.SaveChangesAsync();
                return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

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