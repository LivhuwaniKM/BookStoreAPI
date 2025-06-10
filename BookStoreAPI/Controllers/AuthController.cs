using BSCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AuthController(TokenManager _tokenManager) : BaseController
    {
        [AllowAnonymous]
        [HttpGet("index")]
        public async Task<ActionResult> Login()
        {
            try
            {
                var token = await Task.Run(() => _tokenManager.GetJwtToken());

                return token != null ? Ok(token) : BadRequest();
            }
            catch
            {
                return Unauthorized("Unauthorized access!");
            }
        }
    }
}
