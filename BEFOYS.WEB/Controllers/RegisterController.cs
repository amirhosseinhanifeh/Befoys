using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Register;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private ServiceContext _context;
        public RegisterController(ServiceContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody]ViewBaseRegister model)
        {
            try
            {
                if (!_context.Tbl_Login.Any(x => x.Login_Mobile == model.Mobile) && !_context.Tbl_Login.Any(x => x.Login_Email == model.Email))
                {
                    Tbl_Login login = new Tbl_Login()
                    {
                        Login_FirstName = model.FirstName,
                        Login_LastName = model.LastName,
                        Login_Email = model.Email,
                        Login_Mobile = model.Mobile,
                        Login_PasswordHash = HashPassword.HushPassword(model.Password),
                        Login_PasswordSalt = HashPassword.SaltPassword(model.Password)
                    };
                    _context.Tbl_Login.Add(login);
                    _context.SaveChanges();
                    return Ok(new BaseViewModel<Tbl_Login> { Value = null, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success });
                }
                return Ok(new BaseViewModel<Tbl_Login> { Value = null, Message = ViewMessage.Duplicate, NotificationType = DataLayer.Enums.Enum_NotificationType.success });

            }
            catch (Exception e)
            {
                return Ok(new BaseViewModel<Tbl_Login> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
            }

        }
    }
}