
using BEFOYS.Common.Converts;
using BEFOYS.DataLayer.Model;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BEFOYS.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ServiceContext _context;

        public AccountController(IConfiguration config, ServiceContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody]ViewLogin model)
        {
            var user = _context.TblLogin.Where(x => x.LoginEmail == model.UserName).SingleOrDefault();

            if (user != null && Password.CompareHash(model.Password, user.LoginPasswordSalt, user.LoginPasswordHash))
            {
                if (user.LoginIsBan)
                {
                    return Ok(new { Message = "اکانت کاربر مورد نظر مسدود شده است", token = string.Empty, IsBan = true });
                }

                return Ok(new { Message = "عملیات موفق", token = GenerateJSONWebToken(user), IsBan = false });
            }

            return Ok(new { Message = "نام کاربری یا رمز عبور اشتباه می باشد", token = string.Empty, IsBan = string.Empty });
        }

        /// <summary>
        /// generate token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(TblLogin model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Name, model.LoginGuid.ToString()),
                new Claim(ClaimTypes.Sid,model.LoginId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, model.LoginId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, model.LoginEmail),
                new Claim(JwtRegisteredClaimNames.Jti, model.LoginGuid.ToString()),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}