using BEFOYS.Common.Converts;
using BEFOYS.Common.Messages;
using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.Entity.Supplier;
using BEFOYS.DataLayer.Enums;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels;
using BEFOYS.DataLayer.ViewModels.Register;
using BEFOYS.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IConfiguration _config;
        private ServiceContext _context;
        public RegisterController(ServiceContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
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
                        Login_PasswordSalt = HashPassword.SaltPassword(model.Password),
                        
                    };
                    _context.Tbl_Login.Add(login);


                    switch (model.Role)
                    {
                        case Enum_BaseRole.SUPPLIER:
                            RegisterSupplier(login.Login_ID, model);
                            break;
                        case Enum_BaseRole.CUSTOMER:
                            break;
                    }
                    _context.SaveChanges();
                    string token = GenerateJSONWebToken(login);
                    return Ok(new BaseViewModel<object> { Value = new {token = token } , Message = ViewMessage.SuccessFull, NotificationType = DataLayer.Enums.Enum_NotificationType.success });
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
        new Claim(JwtRegisteredClaimNames.Email, model.Login_Email),
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
        public void RegisterSupplier(int LoginId, ViewBaseRegister model)
        {
            var code = _context.Tbl_Code.FirstOrDefault(x => x.Code_Display == model.Type.ToString());
            Tbl_Supplier supplier = new Tbl_Supplier()
            {
                Supplier_LoginID = LoginId,
                Supplier_TypeCodeID=code.Code_ID
            };
            _context.Tbl_Supplier.Add(supplier);
            if (model.Type == Enum_UserType.HAGHIGHI)
            {
                supplier.SupplierReals = new List<Tbl_SupplierReal>();
                supplier.SupplierReals.Add(new Tbl_SupplierReal());
            }
            else if (model.Type == Enum_UserType.HOGHOGHI)
            {
                supplier.SupplierLegals = new List<Tbl_SupplierLegal>();
                supplier.SupplierLegals.Add(new Tbl_SupplierLegal());
            }
            else if (model.Type == Enum_UserType.SUBUSER)
            {

            }
        }
    }
}