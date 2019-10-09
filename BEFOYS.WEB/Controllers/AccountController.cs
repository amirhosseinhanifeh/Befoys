using BEFOYS.DataLayer.ServiceContext;
using BEFOYS.DataLayer.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
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
            var user = _context.Tbl_Login.FirstOrDefault(x => x.Login_Mobile == model.UserName);
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(model.UserName, user.Login_GUID);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private string GenerateJSONWebToken(string username,Guid uniq)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(JwtRegisteredClaimNames.Email, username),
        new Claim(JwtRegisteredClaimNames.Jti, uniq.ToString())
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