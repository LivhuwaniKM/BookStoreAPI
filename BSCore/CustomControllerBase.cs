using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BSCore
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CustomControllerBase : ControllerBase
    {
    }
}
