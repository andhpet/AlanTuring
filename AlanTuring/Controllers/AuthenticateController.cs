using AlanTuring.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlanTuring.Controllers
{
    [Route("LogIn")]
    public class AuthenticateController : Controller
    {
        private readonly Alan_TuringContext dataContext;

        public AuthenticateController(Alan_TuringContext DataContext)
        {
            dataContext = DataContext;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] User model)
        {
            if (dataContext.Users.Any(u => u.Mail == model.Mail
                    && u.Password == model.Password))
            {
                var authClaims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Mail),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7S79jvOkEdwoRqHx"));
                var token = new JwtSecurityToken(
                    issuer: "https://dotnetdetail.net",
                    audience: "https://dotnetdetail.net",
                    expires: DateTime.Now.AddDays(5),
                    claims: authClaims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}