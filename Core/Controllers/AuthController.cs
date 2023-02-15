using ChallengeAlkemy.Core.User;
using ChallengeAlkemy.Core.Users;
using ChallengeAlkemy.Core.Users.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ChallengeAlkemy.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Users.User>> Register([FromBody] UserDTO userDTO)
        {
            var result = _userService.GetUserByUsername(userDTO.UserName);
            if (result.Result == null) {
                var userACrear = await _userService.CreateUser(userDTO);
                return Ok(userACrear);
            }
            return BadRequest("El Nombre de usuario ya existe");
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]UserDTO userDTO)
        {
            var user = await _userService.GetUserByUsername(userDTO.UserName);
            if (user.Username != userDTO.UserName)
            {
                return BadRequest("User not found");
            }
            if (!_userService.VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(Users.User request)
        {
            var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecret_secretkey!123"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}
