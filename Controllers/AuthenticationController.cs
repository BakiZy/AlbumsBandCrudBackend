using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZavrsniTest.Models;
using ZavrsniTest.Models.DTO;

namespace ZavrsniTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Login parameters invalid.");
            }
            var user = userManager.FindByNameAsync(model.Username).GetAwaiter().GetResult();
            if (user != null && userManager.CheckPasswordAsync(user, model.Password).GetAwaiter().GetResult())
            {

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(1),   // token valid for 2 hours
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                ); ;

                return Ok(new TokenDTO()
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegistrationDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Registration parameters invalid.");
            }

            var userExists = userManager.FindByNameAsync(model.Username).GetAwaiter().GetResult();
            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = userManager.CreateAsync(user, model.Password).GetAwaiter().GetResult();
            if (!result.Succeeded)
            {
                return BadRequest("Validation failed! Please check user details and try again.");
            }

            return Ok();
        }
        
        [HttpPost]
        [Route("change-password")]
        //change password endpoint
        public IActionResult ChangePassword ([FromBody] PasswordChangeDTO model)
        {
  
       
            var user =   userManager.FindByNameAsync(model.Username).GetAwaiter().GetResult();
            if (user == null )
            {
                return NotFound("user doesnt exist");
            }

            var oldPass = userManager.CheckPasswordAsync(user, model.CurrentPassword).GetAwaiter().GetResult();


            if (string.Compare(model.NewPassword, model.ConfirmPassword) != 0 || model.NewPassword.Length < 7)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "passwords cant be empty and must match each other");
            }

            var result = userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword).GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "error123");
            }

            return Ok();
        }

    }
}
