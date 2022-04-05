using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Social_Media_App_Api_.Net_Core.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Social_Media_App_Api_.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private UserManager<AppUsers> _userManager;
        private RoleManager<IdentityRole>  _roleManager;
        private SignInManager<AppUsers> _signInManager;
        public AccountController(UserManager<AppUsers> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUsers> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUsers
                {
                    firstName = user.firstName,
                    lastName = user.lastName,
                    Email = user.email,
                    UserName = user.email,
                    PhoneNumber = user.phone,
                    photoName = String.Empty

                };
                var result = await _userManager.CreateAsync(newUser, user.password);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            return null;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.userName, user.password, false, false);
            if (result.Succeeded)
            {
                var authClaim = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, user.userName),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var secretKsy = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0123456789123456"));
                var token = new JwtSecurityToken(
                    issuer: "0",
                    audience: "user",
                    expires: DateTime.Now.AddDays(1),
                    claims: authClaim,
                    signingCredentials: new SigningCredentials(secretKsy, SecurityAlgorithms.HmacSha256)
                    );
                var a = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    userName = user.userName 
                };
                return Ok(a);

            }
            return null;
        }
    }
}
