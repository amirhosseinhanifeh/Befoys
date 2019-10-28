using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.Common.Utilities;
using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.Entity.Supplier;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IConfiguration _config;
        private ServiceContext _context;
        public RegisterController(ServiceContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpPost]
        public async Task<IActionResult> SetMobile([FromBody] ViewRegister model)
        {
            try
            {

            Tbl_Login login = new Tbl_Login();
            login.Login_Mobile = model.Mobile;
            _context.Tbl_Login.AddAsync(login).Wait();
            var Code = Generate.GenerateCode(6);
            Tbl_Token toke = new Tbl_Token()
            {
                Token_Hush = Code,
                Token_LoginID = login.Login_ID,
                Token_EXP = DateTime.Now.AddMinutes(2),
                Token_Start = DateTime.Now,
                
            };
            _context.Tbl_Token.AddAsync(toke).Wait();

            //Tbl_AccountControl tbl_AccountControl = new Tbl_AccountControl()
            //{
            //    AC_LoginID = login.Login_ID,
            //    AC_BaseRoleID = _context.Tbl_BaseRole.FirstOrDefault(x => x.BR_Display == model.Role.ToString()).BR_ID,
            //    AC_ISBasicAccount = true,

            //};
            //if (model.Type == Enum_UserType.SUBUSER)
            //{
            //    tbl_AccountControl.AC_IsSubUser = true;
            //    //if (model.Code != null)
            //    //{
            //    //    var data = _context.Tbl_SubUserRegisterCode.FirstOrDefault(x => x.SURC_Code == model.Code);
            //    //    if (data != null)
            //    //    {
            //    //        tbl_AccountControl.AC_SURID = data.SURC_SURID;
            //    //    }
            //    //    else
            //    //    {
            //    //        return Ok(new BaseViewModel<object> { Value = "کد وارد شده اشتباه می باشد", Message = ViewMessage.Warning, NotificationType = DataLayer.Enums.Enum_NotificationType.success });

            //    //    }
            //    //}
            //}
            //_context.Tbl_AccountControl.Add(tbl_AccountControl);

            switch (model.Role)
            {
                case Enum_BaseRole.SUPPLIER:
                    RegisterSupplier(login.Login_ID, model.Type);
                    break;
                case Enum_BaseRole.CUSTOMER:
                    break;
            }
            _context.SaveChanges();




            await SmsPortal.SendSmsAsync(reciver: model.Mobile, message: Code);
            //else
            //     EmailPortal.SendEmail(model.UserName,"کد تاییدیه",$"کد تاییدیه شما {Code} می باشد");

            await _context.SaveChangesAsync();

            return Ok(true);

            }
            catch (Exception e)
            {

                return Ok(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Verify([FromBody] ViewVerify model)
        {
            var login = _context.Tbl_Login.FirstOrDefault(x => x.Login_Mobile == model.Mobile);
            if (login != null)
            {
                var token = _context.Tbl_Token.FirstOrDefault(x => x.Token_LoginID == login.Login_ID);
                if (token != null)
                {
                    if (token.Token_Hush == model.Code)
                    {
                        
                        string tokenkey = GenerateJSONWebToken(login);
                        return Ok(new BaseViewModel<object> { Value = new { token = tokenkey }, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success });

                    }
                }
            }
            return Ok(new BaseViewModel<object> { Message = ViewMessage.LoginFailed, NotificationType = DataLayer.Enums.Enum_NotificationType.success });

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
                        Login_Mobile = model.Mobile,
                    };

                    _context.Tbl_Login.Add(login);

                    //پنل پیش فرض گذاشته شود
                    
                    string token = GenerateJSONWebToken(login);
                    return Ok(new BaseViewModel<object> { Value = new { token = token }, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success });
                }
                return Ok(new BaseViewModel<Tbl_Login> { Value = null, Message = ViewMessage.Duplicate, NotificationType = DataLayer.Enums.Enum_NotificationType.warning });

            }
            catch (Exception e)
            {
                return Ok(new BaseViewModel<Tbl_Login> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
            }

        }
        /// <summary>
        /// generate token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="uniq"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(Tbl_Login model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
        new Claim(ClaimTypes.Name, model.Login_Mobile),
        new Claim(ClaimTypes.Sid,model.Login_ID.ToString()),
        new Claim(JwtRegisteredClaimNames.Sub, model.Login_ID.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, model.Login_GUID.ToString()),
        new Claim(ClaimTypes.Role,"Supplier")
    };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [NonAction]
        public void RegisterSupplier(int LoginId, Enum_UserType Type)
        {
            var code = _context.Tbl_Code.FirstOrDefault(x => x.Code_Display == Type.ToString());
            Tbl_Supplier supplier = new Tbl_Supplier()
            {
                Supplier_LoginID = LoginId,
                Supplier_TypeCodeID = code.Code_ID
            };
            _context.Tbl_Supplier.Add(supplier);
            if (Type == Enum_UserType.HAGHIGHI)
            {
                supplier.SupplierReals = new List<Tbl_SupplierReal>();
                supplier.SupplierReals.Add(new Tbl_SupplierReal());
            }
            else if (Type == Enum_UserType.HOGHOGHI)
            {
                supplier.SupplierLegals = new List<Tbl_SupplierLegal>();
                supplier.SupplierLegals.Add(new Tbl_SupplierLegal());
            }
            else if (Type == Enum_UserType.SUBUSER)
            {

            }
        }
    }
}