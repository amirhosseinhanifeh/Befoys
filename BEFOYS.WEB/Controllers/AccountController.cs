
using BEFOYS.DataLayer.Entity.Account;
using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
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
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private ServiceContext _context;

        public AccountController(IConfiguration config,ServiceContext context)
        {
            _config = config;
            _context = context;
        }


        [HttpPost]
        public IActionResult Login([FromBody]ViewLogin model)
        {
            IActionResult response = Unauthorized();
            var user = _context.Tbl_Login.FirstOrDefault(x => (x.Login_Mobile == model.UserName )||(x.Login_Email==model.UserName));
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
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
    }
}