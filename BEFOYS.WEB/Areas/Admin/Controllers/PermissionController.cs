using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Permission;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Permission;
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
    [Authorize]
    public class PermissionController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public PermissionController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_Permission>>> Post([FromBody]ViewPermission model)
        {
            try
            {
                if (model.ID != null)
                {
                    var result = await _context.Tbl_Permission.FindAsync(model.ID);
                    result.Permission_Display = model.DisplayName;
                    result.Permission_Name = model.Name;
                    result.Permission_ISFree = model.IsFree;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_Permission> { Value = result, Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                Tbl_Permission permission = new Tbl_Permission()
                {
                    Permission_Display = model.DisplayName,
                    Permission_Name = model.Name,
                    Permission_ISFree = model.IsFree
                };
                _context.Tbl_Permission.Add(permission);
                await _context.SaveChangesAsync();

                return new BaseViewModel<Tbl_Permission> { Value = permission, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_Permission> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Permission>>> Get()
        {
            return await _context.Tbl_Permission.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_Permission>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.Tbl_Permission.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_Permission.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_Permission> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_Permission> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

            }
            catch (Exception e)
            {
                return Ok(new BaseViewModel<string> { Value = e.Message, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}