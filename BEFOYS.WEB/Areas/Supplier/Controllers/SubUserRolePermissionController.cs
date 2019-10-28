using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.SubUser;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Areas.Supplier.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SubUserRolePermissionController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public SubUserRolePermissionController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<ViewSubUserRolePermission>>> Post(int id, [FromBody]ViewSubUserRolePermission model)
        {
            try
            {
                var list = _context.Tbl_SubUserRolePermission.Where(x => x.SURP_SURID == id);
                _context.Tbl_SubUserRolePermission.RemoveRange(list);
                foreach (var item in model.Ids)
                {

                    Tbl_SubUserRolePermission code = new Tbl_SubUserRolePermission()
                    {
                        SURP_PermissionID = _context.Tbl_Permission.FirstOrDefault(x => x.Permission_GUID == item).Permission_ID,
                        SURP_SURID = id,
                    };
                    _context.Tbl_SubUserRolePermission.Add(code);
                    await _context.SaveChangesAsync();
                }
                return new BaseViewModel<ViewSubUserRolePermission> { Value = null, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewSubUserRolePermission> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_SubUserRolePermission>>> Get()
        {
            return await _context.Tbl_SubUserRolePermission.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Tbl_SubUserRolePermission>>> Get(int id)
        {
            return await _context.Tbl_SubUserRolePermission.Where(x => x.SURP_SURID == id).ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_SubUserRolePermission>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.Tbl_SubUserRolePermission.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_SubUserRolePermission.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_SubUserRolePermission> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_SubUserRolePermission> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_SubUserRolePermission> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}