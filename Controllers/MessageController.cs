using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Social_Media_App_Api_.Net_Core.Data;
using Social_Media_App_Api_.Net_Core.Hubs;
using Social_Media_App_Api_.Net_Core.Models;

namespace Social_Media_App_Api_.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private ApplicationDbContext _db;
        private UserManager<AppUsers> _userManager;
        public MessageController(ApplicationDbContext db, UserManager<AppUsers> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> saveMessage(MessageModel message)
        {
            var user = await _userManager.GetUserAsync(User);
            message.sender = user.UserName;
            return Ok();
        }
    }
}
