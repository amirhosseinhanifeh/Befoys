using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Color;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ColorController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public ColorController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Post([FromBody]ViewColor model)
        {
            try
            {
                if (model.ID != null && model.ID != 0)
                {
                    var result = await _context.TblColors.FindAsync(model.ID);
                    result.ColorsTypeCodeId = model.TypeCodeID;
                    result.ColorsName = model.Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<bool> { Value = true, Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                TblColors color = new TblColors()
                {
                     ColorsName=model.Name,
                     ColorsTypeCodeId=model.TypeCodeID
                };
                _context.TblColors.Add(color);
                await _context.SaveChangesAsync();

                return new BaseViewModel<bool> { Value =true, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPermission>>> Get()
        {
            return await _context.TblPermission.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<bool>>> Delete([FromBody] int? id)
        {
            try
            {
                var data = await _context.TblColors.FindAsync(id);
                if (data != null)
                {
                    _context.TblColors.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<bool> { Value = true, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.warning };

            }
            catch (Exception e)
            {
                return new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}