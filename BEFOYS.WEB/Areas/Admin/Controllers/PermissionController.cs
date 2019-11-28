using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public PermissionController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<ViewPermission>>> Post([FromBody]ViewPermission model)
        {
            try
            {
                if (model.ID != null && model.ID != 0)
                {
                    var result = await _context.TblPermission.FindAsync(model.ID);
                    result.PermissionDisplay = model.DisplayName;
                    result.PermissionName = model.Name;
                    result.PermissionIsFree = model.IsFree;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<ViewPermission> { Value = new ViewPermission(result), Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                TblPermission permission = new TblPermission()
                {
                    PermissionDisplay = model.DisplayName,
                    PermissionName = model.Name,
                    PermissionIsFree = model.IsFree,
                };
                _context.TblPermission.Add(permission);

                TblGroupPermission gp = new TblGroupPermission()
                {
                    GpGroupId = model.Group_ID,
                    GpPermissionId = permission.PermissionId
                };
                _context.TblGroupPermission.Add(gp);

                await _context.SaveChangesAsync();

                return new BaseViewModel<ViewPermission> { Value = new ViewPermission(permission), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewPermission> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPermission>>> Get()
        {
            return await _context.TblPermission.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblPermission>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.TblPermission.FindAsync(id);
                if (data != null)
                {
                    _context.TblPermission.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblPermission> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblPermission> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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