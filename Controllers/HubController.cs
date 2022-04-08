using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Social_Media_App_Api_.Net_Core.Data;
using Social_Media_App_Api_.Net_Core.Hubs;
using Social_Media_App_Api_.Net_Core.Models;
using Social_Media_App_Api_.Net_Core.Services;

namespace Social_Media_App_Api_.Net_Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private ApplicationDbContext _db;
        private UserManager<AppUsers> _userManager;
        public HubController(ApplicationDbContext db, UserManager<AppUsers> userManager)
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

        [HttpGet("getActiveUserList")]
        public async Task<IActionResult> getActiveUserList()
        {
            return Ok(ConnectedUser.Ids);
        }


        [HttpPost("sendMessage")]
        public async Task<IActionResult> sendMessage(MessageModel msg)
        {
            if (msg == null) return BadRequest(msg);
            await _db.messageD.AddAsync(msg);
            await _db.SaveChangesAsync();
            return Ok(await _db.messageD.Where(x=>x.sender == msg.sender && x.receiver == msg.receiver).ToListAsync());
        }

        [HttpPost("getMessage")]
        public async Task<IActionResult> getMessage([FromQuery]string sender, string receiver)
        {
            if (sender == null || receiver == null ) return BadRequest();
            return Ok(await _db.messageD.Where(x => x.sender == sender && x.receiver == receiver).ToListAsync());
        }
    }
}
