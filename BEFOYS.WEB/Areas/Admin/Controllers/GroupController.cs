using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Group;
using BEFOYS.DataLayer.Entity.Permission;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Group;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class GroupController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public GroupController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_Group>>> Post([FromBody]ViewGroup model)
        {
            try
            {
                if (model.ID != null && model.ID != 0)
                {
                    var result = await _context.Tbl_Group.FindAsync(model.ID);
                    result.Group_Display = model.Display;
                    result.Group_Name = model.Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_Group> { Value = result, Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                Tbl_Group permission = new Tbl_Group()
                {
                    Group_Display = model.Display,
                    Group_Name = model.Name,
                };
                _context.Tbl_Group.Add(permission);
                await _context.SaveChangesAsync();

                return new BaseViewModel<Tbl_Group> { Value = permission, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_Group> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_GroupPermission>>> Get()
        {
            return await _context.Tbl_GroupPermission.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_GroupPermission>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.Tbl_GroupPermission.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_GroupPermission.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_GroupPermission> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_GroupPermission> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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