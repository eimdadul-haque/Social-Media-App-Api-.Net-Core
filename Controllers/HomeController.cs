using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Social_Media_App_Api_.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var a = new
            {
                a = "1",
                b = "2"
            };
            return Ok(a);
        }
    }
}
