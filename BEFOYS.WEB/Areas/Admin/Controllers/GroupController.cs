using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Group;
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
        public async Task<ActionResult<BaseViewModel<TblGroup>>> Post([FromBody]ViewGroup model)
        {
            try
            {
                if (model.ID != null && model.ID != 0)
                {
                    var result = await _context.TblGroup.FindAsync(model.ID);
                    result.GroupDisplay = model.Display;
                    result.GroupName = model.Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblGroup> { Value = result, Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                TblGroup permission = new TblGroup()
                {
                    GroupDisplay = model.Display,
                    GroupName = model.Name,
                };
                _context.TblGroup.Add(permission);
                await _context.SaveChangesAsync();

                return new BaseViewModel<TblGroup> { Value = permission, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<TblGroup> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblGroupPermission>>> Get()
        {
            return await _context.TblGroupPermission.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblGroupPermission>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.TblGroupPermission.FindAsync(id);
                if (data != null)
                {
                    _context.TblGroupPermission.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblGroupPermission> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblGroupPermission> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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