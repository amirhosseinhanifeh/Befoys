using System;
using System.Collections.Generic;
using System.Linq;
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
                    var result = await _context.TblCode.FindAsync(model.ID);
                    result.CodeDisplay = model.Code_Display;
                    result.CodeName = model.Code_Name;
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<ViewCode> { Value = new ViewCode(result), Message = ViewMessage.SuccessFullEdited, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

                }
                TblCode code = new TblCode()
                {
                    CodeDisplay = model.Code_Display,
                    CodeName = model.Code_Name,
                    CodeCgid = model.Code_CGID
                };
                _context.TblCode.Add(code);
                await _context.SaveChangesAsync();

                return new BaseViewModel<ViewCode> { Value = new ViewCode(code), Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewCode> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCode>>> Get()
        {
            return await _context.TblCode.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCode>> Get(int id)
        {
            return await _context.TblCode.FindAsync(id);
        }
        [HttpGet("{GroupId}")]
        public async Task<ActionResult<BaseViewModel<List<ViewCode>>>> GetByCodeGroup(Guid GroupId){

            return new BaseViewModel<List<ViewCode>> {Value=await _context.TblCode.Where(x=>x.CodeCg.CgGuid == GroupId).Select(x=>new ViewCode(x)).ToListAsync() };
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<TblCode>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.TblCode.FindAsync(id);
                if (data != null)
                {
                    _context.TblCode.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<TblCode> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<TblCode> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            catch (Exception e)
            {
                return new BaseViewModel<TblCode> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}