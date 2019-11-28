using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
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
        public async Task<ActionResult<BaseViewModel<List<TblPanelTypePermission>>>> Post([FromBody]ViewPanelTypePermission model)
        {
            try
            {
                var panel = _context.TblPanelType.FirstOrDefault(x => x.PtGuid == model.ID);
                List<TblPanelTypePermission> list = new List<TblPanelTypePermission>();
                foreach (var item in model.Permissions)
                {
                    var per = _context.TblPermission.FirstOrDefault(x => x.PermissionGuid == item);
                    list.Add(new TblPanelTypePermission()
                    {
                        PtpPermissionId = per.PermissionId,
                        PtpPtid = panel.PtId
                    });
                }

                _context.TblPanelTypePermission.AddRange(list);

                await _context.SaveChangesAsync();

                return new BaseViewModel<List<TblPanelTypePermission>> { Value = list, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<List<TblPanelTypePermission>> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPanelTypePermission>>> Get()
        {
            return await _context.TblPanelTypePermission.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblPanelTypePermission>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.TblPanelTypePermission.FindAsync(id);
                if (data != null)
                {
                    _context.TblPanelTypePermission.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblPanelTypePermission> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblPanelTypePermission> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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