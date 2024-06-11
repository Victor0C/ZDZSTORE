using Microsoft.AspNetCore.Mvc;
using ZDZSTORE.Auth.DTO;
using ZDZSTORE.Auth.Model;

namespace ZDZSTORE.Auth
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<UserToken>> login(AuthDTO authDTO)
        {
            var token = await _authService.GenerateToken(authDTO);

            if (token == null) { return Unauthorized("Invalid credentials"); }

            return Ok(new UserToken
            {
                accessToken = $"Bearer {token}"
            });
        }
    }
}
