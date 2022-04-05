using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Media_App_Api_.Net_Core.Data;
using Social_Media_App_Api_.Net_Core.Models;

namespace Social_Media_App_Api_.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {

        private ApplicationDbContext _db;
        private UserManager<AppUsers> _userManager;
        public CommentController(ApplicationDbContext db, UserManager<AppUsers> userManager)
        {
            _db = db;
            _userManager = userManager;
        }


        [HttpGet("getComment/{id}")]
        public async Task<IActionResult> getComment([FromRoute]int id)
        {
            if (id > 0)
            {
                return Ok(await _db.commentD.Where(x=>x.PostModelId == id).ToListAsync());

            }
            return BadRequest();
        }

        [HttpPost("addComment")]
        public async Task<IActionResult> addComment(CommrntModel comment)
           {
            if (ModelState.IsValid)
            {
                var user =await _userManager.FindByNameAsync(User.Identity.Name);
                comment.appUserId = user.Id;
                await _db.commentD.AddAsync(comment);
                await _db.SaveChangesAsync();
                return Ok();

            }
            return BadRequest();
        }
    }
}
