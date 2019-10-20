using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Panel;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Panel;
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
    public class PanelTypePermissionController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public PanelTypePermissionController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<List<Tbl_PanelTypePermission>>>> Post([FromBody]ViewPanelTypePermission model)
        {
            try
            {
                var panel = _context.Tbl_PanelType.FirstOrDefault(x => x.PT_GUID == model.ID);
                List<Tbl_PanelTypePermission> list = new List<Tbl_PanelTypePermission>();
                foreach (var item in model.Permissions)
                {
                    var per = _context.Tbl_Permission.FirstOrDefault(x => x.Permission_GUID == item);
                    list.Add(new Tbl_PanelTypePermission()
                    {
                        PTP_PermissionID = per.Permission_ID,
                        PTP_PTID = panel.PT_ID
                    });
                }

                _context.Tbl_PanelTypePermission.AddRange(list);

                await _context.SaveChangesAsync();

                return new BaseViewModel<List<Tbl_PanelTypePermission>> { Value = list, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<List<Tbl_PanelTypePermission>> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_PanelTypePermission>>> Get()
        {
            return await _context.Tbl_PanelTypePermission.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_PanelTypePermission>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.Tbl_PanelTypePermission.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_PanelTypePermission.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_PanelTypePermission> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_PanelTypePermission> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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