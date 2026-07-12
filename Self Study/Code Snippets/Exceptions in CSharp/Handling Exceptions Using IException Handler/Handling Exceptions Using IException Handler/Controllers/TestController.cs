using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Handling_Exceptions_Using_IException_Handler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("throw")]
        public IActionResult ThrowException()
        {
            throw new Exception("This is a test exception from controller.");
        }
    }
}
