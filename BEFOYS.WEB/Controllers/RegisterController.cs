using BEFOYS.Common.AppUser;
using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.Common.Utilities;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Register;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
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
        public async Task<IActionResult> HarrisLogin([FromBody] ViewRegister model)
        {


            var Result = _context.TblLogin.FirstOrDefault(x => x.LoginMobile == model.Mobile);
            if (Result == null)
            {
                return Ok(new { Message = "کاربر یافت نشد", IsAny = false, IsLogin = false });
            }
            return (await Registeration(model));
        }
        /// <summary>
        /// ارسال شماره و دریافت کد تاییدیه
        /// </summary>
        /// <param name="Mobile">شماره موبایل</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///     Mobile:"09354547295"
        ///     }
        /// </remarks>
        /// <returns>خروجی کد تاییدیه می باشد</returns>
        [HttpPost]
        public async Task<IActionResult> Registeration([FromBody] ViewRegister Mobile)
        {
            try
            {
                var Code = Generate.GenerateCode(6);
                var Result = _context.TblLogin.FirstOrDefault(x => x.LoginMobile == Mobile.Mobile);
                TblLogin login = new TblLogin();
                if (Result == null)
                {

                    login.LoginMobile = Mobile.Mobile;
                    _context.TblLogin.AddAsync(login).GetAwaiter();
                }
                else
                {
                    login = Result;
                }
                TblToken toke = new TblToken()
                {
                    TokenHush = Code,
                    TokenLoginId = login.LoginId,
                    TokenExp = DateTime.Now.AddMinutes(2),
                    TokenStart = DateTime.Now,

                };
                _context.TblToken.Add(toke);

                //switch (model.Role)
                //{
                //    case Enum_BaseRole.SUPPLIER:
                //        RegisterSupplier(login.Login_ID, model.Type);
                //        break;
                //    case Enum_BaseRole.CUSTOMER:
                //        break;
                //}

                try
                {
                    await SmsPortal.SendSmsAsync(reciver: Mobile.Mobile, message: Code);
                }
                catch (Exception e)
                {
                    return Ok(new { Smserror = true });
                }
                //else
                //     EmailPortal.SendEmail(model.UserName,"کد تاییدیه",$"کد تاییدیه شما {Code} می باشد");
                await _context.SaveChangesAsync();


                return Ok(new { IsLogin = true, IsAny = true, smserror = false });

            }
            catch (Exception e)
            {

                return Ok(new { IsLogin = false, smserror = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Verify([FromBody] ViewVerify model)
        {
            var login = await _context.TblLogin.FirstOrDefaultAsync(x => x.LoginMobile == model.Mobile);
            if (login != null)
            {
                //var token = _context.TblToken.AsEnumerable().Where(x => x.TokenLoginId == login.LoginId && x.TokenExp > DateTime.Now).LastOrDefault();
                //if (token == null)
                //{
                //if (token.TokenHush == model.Code)
                //{

                string tokenkey = GenerateJSONWebToken(login);
                string panel = null;
                if (login.LoginIsRegister)
                {
                    panel = login.TblEmployee.First().EmployeeOrganization.OrganizationOt.OtName;
                }
                return Ok(new { isOK = true, token = tokenkey, IsRegister = login.LoginIsRegister, panel = panel });

                //}
                //else
                //{
                //    return Ok(new { isOK = false });
                //}
                //}
            }
            return Ok(new BaseViewModel<object> { Message = ViewMessage.LoginFailed, NotificationType = DataLayer.Enums.Enum_NotificationType.success });

        }

        [HttpPost]
        public async Task<BaseViewModel<bool>> RegisterEmployeeCode([FromBody] int Code)
        {
            try
            {
                var code = await _context.TblEmployeeRegistrationCode.FirstOrDefaultAsync(x => x.SurcCode == Code.ToString());

                if (code != null)
                {
                    return new BaseViewModel<bool> { Message = ViewMessage.SuccessFull, NotificationType = Enum_NotificationType.success, Value = true };
                }
                return new BaseViewModel<bool> { Message = "کد معرف اشتباه می باشد", NotificationType = Enum_NotificationType.warning, Value = false };

            }
            catch (Exception e)
            {

                return  new BaseViewModel<bool> { Value = false, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error };

            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee([FromBody]ViewRegisterEmployee model)
        {
                var user = User.Identity.UserID();
            var code = await _context.TblEmployeeRegistrationCode.FirstOrDefaultAsync(x => x.SurcCode == model.Code);

            var login = await _context.TblLogin.FirstOrDefaultAsync(x => x.LoginId == user);
                login.LoginFirstName = model.FirstName;
                login.LoginLastName = model.LastName;
                login.LoginEmail = model.Email;

                var employee = await _context.TblEmployee.FirstOrDefaultAsync(x => x.EmployeeId == code.ErcEmployeeId);
                employee.EmployeeLoginId = login.LoginId;

                await _context.SaveChangesAsync();

                return Ok(new {Message="با موفقیت ثبت شد",IsOK=true });
        }
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]ViewBaseRegister model)
        //{
        //    try
        //    {
        //        if (!_context.TblLogin.Any(x => x.LoginMobile == model.Mobile) && !_context.TblLogin.Any(x => x.LoginEmail == model.Email))
        //        {

        //            TblLogin login = new TblLogin()
        //            {
        //                LoginMobile = model.Mobile,
        //            };

        //            await _context.TblLogin.AddAsync(login);

        //            //پنل پیش فرض گذاشته شود

        //            string token = GenerateJSONWebToken(login);
        //            return Ok(new BaseViewModel<object> { Value = new { token = token }, Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success });
        //        }
        //        return Ok(new BaseViewModel<TblLogin> { Value = null, Message = ViewMessage.Duplicate, NotificationType = DataLayer.Enums.Enum_NotificationType.warning });

        //    }
        //    catch (Exception e)
        //    {
        //        return Ok(new BaseViewModel<TblLogin> { Value = null, Message = ViewMessage.Error, NotificationType = DataLayer.Enums.Enum_NotificationType.error });
        //    }

        //}
        /// <summary>
        /// generate token
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        private string GenerateJSONWebToken(TblLogin model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
        new Claim(ClaimTypes.Name, model.LoginMobile),
        new Claim(ClaimTypes.Sid,model.LoginId.ToString()),
        new Claim(JwtRegisteredClaimNames.Sub, model.LoginId.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, model.LoginGuid.ToString()),
        //new Claim(ClaimTypes.Role,model.AccountControl.BaseRole.BR_Display)
    };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(2),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [NonAction]
        public void RegisterSupplier(int LoginId, Enum_UserType Type)
        {
            var code = _context.TblCode.FirstOrDefault(x => x.CodeDisplay == Type.ToString());
            //Tbl_Supplier supplier = new Tbl_Supplier()
            //{
            //    Supplier_LoginID = LoginId,
            //    Supplier_TypeCodeID = code.Code_ID
            //};
            //_context.Tbl_Supplier.Add(supplier);
            //if (Type == Enum_UserType.HAGHIGHI)
            //{
            //    supplier.SupplierReals = new List<Tbl_SupplierReal>();
            //    supplier.SupplierReals.Add(new Tbl_SupplierReal());
            //}
            //else if (Type == Enum_UserType.HOGHOGHI)
            //{
            //    supplier.SupplierLegals = new List<Tbl_SupplierLegal>();
            //    supplier.SupplierLegals.Add(new Tbl_SupplierLegal());
            //}
            //else if (Type == Enum_UserType.SUBUSER)
            //{

            //}
        }
    }
}