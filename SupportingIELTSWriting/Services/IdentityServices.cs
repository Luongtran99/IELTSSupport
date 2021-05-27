using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SupportingIELTSWriting.Models;
using SupportingIELTSWriting.Models.Entities;
using SupportingIELTSWriting.Options;

namespace SupportingIELTSWriting.Services
{
    public class IdentityServices : IIdentityServices
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JwtOptions _jwtOptions;
        private readonly IConfiguration _configuration;
        private readonly HttpContext httpContext;
        public IdentityServices(UserManager<User> userManager,SignInManager<User> signInManager, JwtOptions jwtOptions, IConfiguration configuration)
        {
            //httpContext = ct;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtOptions = jwtOptions;
            _configuration = configuration;
        }

        // generate token for user
        private AuthResult GeneratingAuthResultForUser(User user)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(type:JwtRegisteredClaimNames.Sub, value:user.Email),
                    new Claim(type:JwtRegisteredClaimNames.Jti, value:Guid.NewGuid().ToString()),
                    new Claim(type:JwtRegisteredClaimNames.Email, value:user.Email),
                    new Claim(type:"id", value:user.Id)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = TokenHandler.CreateToken(tokenDescriptor);

            return new AuthResult
            {
                isSuccess = true,
                userId = user.Id,
                Token = TokenHandler.WriteToken(token)
            };
        }

        public async Task<AuthResult> LoginAsync(string email, string password, bool rememberMe = false)
        {

            // check if account is login in another computer
            

            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return new AuthResult
                {
                    Message = new[] { "user doesn't exist" }
                };
            }
            //var checkPassword = await _userManager.CheckPasswordAsync(user, password);

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);


            if (result.Succeeded)
            {
                // set time duration
                var tokenLifeTime = _configuration.GetValue("TokenLifeTimeMinutes", 120);
                var props = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(tokenLifeTime),
                    AllowRefresh = true,
                    RedirectUri = "/login"
                };

                // check if it is remember me
                if (rememberMe)
                {
                    var permanentTokenLifeTime = _configuration.GetValue("PermanentTokenLifeTime", 365);
                    props.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(permanentTokenLifeTime);
                    props.IsPersistent = true;
                }

                await _signInManager.SignInAsync(user, props);

                return GeneratingAuthResultForUser(user);
            }

            if (result.IsLockedOut)
            {

            }
            

            return new AuthResult
            {
                Message = new[] { "Username/Password is incorrect" }
            };
        }

        public async Task<AuthResult> RegisterAsync(string email, string password)
        {
            var exits = await _userManager.FindByEmailAsync(email); //?????/

            if (exits != null)
            {
                return new AuthResult
                {
                    Message = new[] { "email has been used" }
                };
            }

            var newUser = new User
            {
                Email = email,
                UserName = email
            };

            var createUser = await _userManager.CreateAsync(newUser, password); // microsoft password was hashed

            
            if (!createUser.Succeeded)
            {
                return new AuthResult
                {
                    Message = createUser.Errors.Select(p => p.Description)
                };
            }

            await _signInManager.SignInAsync(newUser, isPersistent: false);

            return GeneratingAuthResultForUser(newUser);

        }

        public async Task<bool> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        //public Task<AuthResult> LoginAsync(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<AuthResult> ChangePassword(string pasword)
        {
            // change password
            


            return null;
        }
    }
}
