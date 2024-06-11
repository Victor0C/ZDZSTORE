using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZDZSTORE.Auth.DTO;
using ZDZSTORE.User;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.Auth
{
    public class AuthService
    {
        private UserRepository _userRepository;
        private IPasswordHasher<UserModel> _passwordHasher;
        private IConfiguration _configuration;

        public AuthService(UserRepository userRepository, IPasswordHasher<UserModel> passwordHasher, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<UserModel?> AuthenticateAsync(AuthDTO authDTO)
        {
            UserModel? user = await _userRepository.GetOneByEmail(authDTO.email);
            if (user == null) { return null; }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.password, authDTO.password);

            if (passwordVerificationResult == PasswordVerificationResult.Failed) { return null; }

            return user;
        }

        public async Task<string?> GenerateToken(AuthDTO authDTO)
        {
            UserModel? user = await AuthenticateAsync(authDTO);
            if (user == null) { return null; }

            var JWTclaims = new[]
            {
                new Claim("id", user.id),
                new Claim("email", user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetConnectionString("JWTKey")));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var JWTexpiration = DateTime.UtcNow.AddDays(2);

            JwtSecurityToken token = new JwtSecurityToken(
                claims: JWTclaims,
                expires: JWTexpiration,
                signingCredentials: credentials
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
