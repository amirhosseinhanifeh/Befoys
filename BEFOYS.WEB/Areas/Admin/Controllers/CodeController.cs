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
    public class CodeController : ControllerBase, IDisposable
    {
        private ServiceContext _context;

        public CodeController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<ViewCode>>> Post([FromBody]ViewCode model)
        {
            try
            {
                if (model.ID != null && model.ID != 0)
                {
                    var result = await _context.Tbl_Code.FindAsync(model.ID);
                    result.Code_Display = model.Code_Display;
                    result.Code_Name = model.Code_Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<ViewCode> { Value = new ViewCode(result), Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                Tbl_Code code = new Tbl_Code()
                {
                    Code_Display = model.Code_Display,
                    Code_Name = model.Code_Name,
                    Code_CGID = model.Code_CGID
                };
                _context.Tbl_Code.Add(code);
                await _context.SaveChangesAsync();

                return new BaseViewModel<ViewCode> { Value = new ViewCode(code), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewCode> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_Code>>> Get()
        {
            return await _context.Tbl_Code.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbl_Code>> Get(int id)
        {
            return await _context.Tbl_Code.FindAsync(id);
        }
        [HttpGet("{GroupId}")]
        public async Task<ActionResult<BaseViewModel<List<ViewCode>>>> GetByCodeGroup(Guid GroupId){

            return new BaseViewModel<List<ViewCode>> {Value=await _context.Tbl_Code.Where(x=>x.CodeGroup.CG_GUID == GroupId).Select(x=>new ViewCode(x)).ToListAsync() };
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_Code>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.Tbl_Code.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_Code.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_Code> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_Code> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_Code> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}