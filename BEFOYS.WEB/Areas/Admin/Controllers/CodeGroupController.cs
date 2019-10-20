using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Code;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Code;
using Microsoft.AspNetCore.Http;
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
                    var result = await _context.Tbl_CodeGroup.FindAsync(model.ID);
                    result.CG_Display = model.CG_Display;
                    result.CG_Name = model.CG_Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<ViewCodeGroup> { Value = new ViewCodeGroup(result), Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                Tbl_CodeGroup code = new Tbl_CodeGroup()
                {
                    CG_Display = model.CG_Display,
                    CG_Name = model.CG_Name,
                };
                _context.Tbl_CodeGroup.Add(code);
                await _context.SaveChangesAsync();

                return new BaseViewModel<ViewCodeGroup> { Value = new ViewCodeGroup(code), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewCodeGroup> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_CodeGroup>>> Get()
        {
            return await _context.Tbl_CodeGroup.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_CodeGroup>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.Tbl_CodeGroup.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_CodeGroup.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_CodeGroup> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_CodeGroup> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_CodeGroup> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}