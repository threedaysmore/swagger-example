using Microsoft.AspNetCore.Mvc;

namespace SwaggerTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class NonPublicController : ControllerBase
    {
        [HttpGet]
        public string SecretMethod()
        {
            return "I'M A SECRET!";
        }
    }
}