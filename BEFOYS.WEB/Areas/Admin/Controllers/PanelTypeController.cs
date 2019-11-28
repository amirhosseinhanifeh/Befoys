using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Panel;
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
        public async Task<ActionResult<BaseViewModel<TblPanelType>>> Post([FromBody]ViewPanelType model)
        {
            try
            {
                if (model.ID != null && model.ID != 0)
                {
                    var result = await _context.TblPanelType.FindAsync(model.ID);
                    result.PtDisplay = model.Display;
                    result.PtName = model.NAME;
                    result.PtIsFree = model.ISFree;
                    result.PtPrice = model.Price;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblPanelType> { Value = result, Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                TblPanelType permission = new TblPanelType()
                {
                    PtDisplay = model.Display,
                    PtName = model.NAME,
                    PtIsFree = model.ISFree,
                    PtPrice = model.Price,

                };
                _context.TblPanelType.Add(permission);

                await _context.SaveChangesAsync();

                return new BaseViewModel<TblPanelType> { Value = permission, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<TblPanelType> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPanelType>>> Get()
        {
            return await _context.TblPanelType.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblPanelType>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.TblPanelType.FindAsync(id);
                if (data != null)
                {
                    _context.TblPanelType.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblPanelType> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblPanelType> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

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