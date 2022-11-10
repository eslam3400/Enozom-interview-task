using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Security.Cryptography;
using TaskModels;
using TaskModels.DTOs.Auth;
using TaskModels.DTOs.User;
using TaskRepositories.Interfaces;
using TaskServices.Interfacs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TaskServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository repo;
        private readonly IConfiguration config;
        public AuthService(IUserRepository repo, IConfiguration config) {
            this.repo = repo;
            this.config = config;
        }

        private HashData CreateHashedPassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                return new HashData
                {
                    Salt = hmac.Key,
                    Password = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password))
                };
            }
        }

        private bool VerifyHashedPassword(string password, User user)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var hashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return user.Password.SequenceEqual(hashed);
            }
        }

        private string GenerateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim (ClaimTypes.Name, user.UserName),
                new Claim (ClaimTypes.Role, nameof(user.Role))
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(16),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string Login(UserLoginDTO _user)
        {
            var user = repo.Get(_user.Username);
            if (user == null) return null;
            if (VerifyHashedPassword(_user.Password, user)) return GenerateToken(user);
            return null;
        }

        public void Register(UserRegisterDTO user)
        {
            var hashedData = CreateHashedPassword(user.Password);
            repo.Add(new User
            {
                Email = user.Email,
                Name = user.Name,
                Password = hashedData.Password,
                PasswordSalt = hashedData.Salt,
                Role = user.Role,
                UserName = user.UserName
            });
            repo.Save();
        }
    }
}
