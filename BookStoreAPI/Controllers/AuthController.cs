using BSCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(JWTAuth jwtObject) : ControllerBase
    {
        private readonly JWTAuth jwtObject = jwtObject;

        [AllowAnonymous]
        [HttpGet("index")]
        public async Task<ActionResult> Login()
        {
            try
            {
                var token = await Task.Run(() => jwtObject.GetJwtToken());

                if (!string.IsNullOrEmpty(token))
                    return Ok();
                else
                    return Unauthorized("Unauthorized access!");
            }
            catch
            {
                return Unauthorized("Unauthorized access!");
            }
        }
    }
}
