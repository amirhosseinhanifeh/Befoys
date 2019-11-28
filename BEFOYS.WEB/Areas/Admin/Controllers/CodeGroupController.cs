using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Code;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEFOYS.WEB.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CodeGroupController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public CodeGroupController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<ViewCodeGroup>>> Post([FromBody]ViewCodeGroup model)
        {
            try
            {
                if (model.ID != null)
                {
                    var result = await _context.TblCodeGroup.FindAsync(model.ID);
                    result.CgDisplay = model.CG_Display;
                    result.CgName = model.CG_Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<ViewCodeGroup> { Value = new ViewCodeGroup(result), Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                TblCodeGroup code = new TblCodeGroup()
                {
                    CgDisplay = model.CG_Display,
                    CgName = model.CG_Name,
                };
                _context.TblCodeGroup.Add(code);
                await _context.SaveChangesAsync();

                return new BaseViewModel<ViewCodeGroup> { Value = new ViewCodeGroup(code), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewCodeGroup> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCodeGroup>>> Get()
        {
            return await _context.TblCodeGroup.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblCodeGroup>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.TblCodeGroup.FindAsync(id);
                if (data != null)
                {
                    _context.TblCodeGroup.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblCodeGroup> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblCodeGroup> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            catch (Exception e)
            {
                return new BaseViewModel<TblCodeGroup> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}