using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Panel;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Panel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PanelTypeController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public PanelTypeController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_PanelType>>> Post([FromBody]ViewPanelType model)
        {
            try
            {
                if (model.ID != null && model.ID != 0)
                {
                    var result = await _context.Tbl_PanelType.FindAsync(model.ID);
                    result.PT_Display = model.Display;
                    result.PT_NAME = model.NAME;
                    result.PT_ISFree = model.ISFree;
                    result.PT_Price = model.Price;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_PanelType> { Value = result, Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                Tbl_PanelType permission = new Tbl_PanelType()
                {
                    PT_Display = model.Display,
                    PT_NAME = model.NAME,
                    PT_ISFree = model.ISFree,
                    PT_Price = model.Price,

                };
                _context.Tbl_PanelType.Add(permission);

                await _context.SaveChangesAsync();

                return new BaseViewModel<Tbl_PanelType> { Value = permission, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_PanelType> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_PanelType>>> Get()
        {
            return await _context.Tbl_PanelType.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_PanelType>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.Tbl_PanelType.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_PanelType.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_PanelType> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_PanelType> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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