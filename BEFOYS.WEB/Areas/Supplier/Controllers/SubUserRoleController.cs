using BEFOYS.Common.AppUser;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.SubUser;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Supplier;
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
    public class SubUserRoleController : ControllerBase
    {
        private ServiceContext _context;

        public SubUserRoleController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<BaseViewModel<ViewSubUserRole>> Post([FromBody]ViewSubUserRole model)
        {
            try
            {
                var user = User.Identity.UserID();
                if (model.ID == 0 && model.ID == null)
                {

                    Tbl_SubUserRole role = new Tbl_SubUserRole()
                    {
                        SUR_Display = model.SUR_Display,
                        SUR_Name = model.SUR_Name,
                        SUR_LoginID = user
                    };
                    _context.Add(role);
                }
                else
                {
                    var Result = await _context.Tbl_SubUserRole.FindAsync(model.ID);
                    Result.SUR_Display = model.SUR_Display;
                    Result.SUR_Name = model.SUR_Name;
                }
                await _context.SaveChangesAsync();
                return new BaseViewModel<ViewSubUserRole> { Value = model, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success };

            }
            catch (Exception e)
            {
                return new BaseViewModel<ViewSubUserRole>
                {
                    Value = null,
                    Message = ViewMessage.Error,
                    NotificationType = DataLayer.Enums.Enum_NotificationType.error
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ViewSubUserRole>>> Get()
        {
            var user = User.Identity.UserID();
            return await _context.Tbl_SubUserRole.Where(x => x.SUR_LoginID == user).Select(x => new ViewSubUserRole(x)).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbl_SubUserRole>> Get(int id)
        {
            return await _context.Tbl_SubUserRole.FindAsync(id);
        }
    }
}