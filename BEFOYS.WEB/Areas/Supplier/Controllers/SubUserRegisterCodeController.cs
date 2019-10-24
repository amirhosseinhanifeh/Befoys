using BEFOYS.Common.AppUser;
using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.SubUser;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
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
    public class SubUserRegisterCodeController : ControllerBase,IDisposable
    {
        private ServiceContext _context;

        public SubUserRegisterCodeController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_SubUserRegisterCode>>> Post(int id)
        {
            try
            {
                var user = User.Identity.UserID();
                Tbl_SubUserRegisterCode code = new Tbl_SubUserRegisterCode()
                {
                    SURC_LoginID = user,
                    SURC_SURID = id,
                    SURC_Code=Generate.GenerateCode(6)
                };
                _context.Tbl_SubUserRegisterCode.Add(code);
                await _context.SaveChangesAsync();
                return new BaseViewModel<Tbl_SubUserRegisterCode> { Value = code, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };


            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_SubUserRegisterCode> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbl_SubUserRegisterCode>>> Get()
        {
            return await _context.Tbl_SubUserRegisterCode.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult<BaseViewModel<Tbl_SubUserRegisterCode>>> Delete([FromBody]int? id)
        {
            try
            {
                var data = await _context.Tbl_SubUserRegisterCode.FindAsync(id);
                if (data != null)
                {
                    _context.Tbl_SubUserRegisterCode.Remove(data);
                    await _context.SaveChangesAsync();
                    return new BaseViewModel<Tbl_SubUserRegisterCode> { Value = null, Message = ViewMessage.Remove, NotificationType = DataLayer.Enums.Enum_NotificationType.success };
                }
                return new BaseViewModel<Tbl_SubUserRegisterCode> { Value = null, Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.notfound };

            }
            catch (Exception e)
            {
                return new BaseViewModel<Tbl_SubUserRegisterCode> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}