using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Role;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public RoleController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<ViewBaseRole>>> Post([FromBody]ViewBaseRole model)
        {
            try
            {
                if (model.ID != null)
                {
                    var result = await _context.Tbl_BaseRole.FindAsync(model.ID);
                    result.BR_Display = model.DisplayName;
                    result.BR_Name = model.Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<ViewBaseRole> { Value = new ViewBaseRole(result), Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                Tbl_BaseRole baseRole = new Tbl_BaseRole()
                {
                    BR_Display = model.DisplayName,
                    BR_Name = model.Name,
                };
                _context.Tbl_BaseRole.Add(baseRole);
                await _context.SaveChangesAsync();

                return new BaseViewModel<ViewBaseRole> { Value = new ViewBaseRole(baseRole), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewBaseRole> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_BaseRole>>> Get()
        {
            return await _context.Tbl_BaseRole.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_BaseRole>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.Tbl_BaseRole.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_BaseRole.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_BaseRole> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_BaseRole> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_BaseRole> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}