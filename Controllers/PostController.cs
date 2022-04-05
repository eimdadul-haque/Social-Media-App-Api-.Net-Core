using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_Media_App_Api_.Net_Core.Data;
using Social_Media_App_Api_.Net_Core.Models;
using Social_Media_App_Api_.Net_Core.Services;

namespace Social_Media_App_Api_.Net_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<AppUsers>  _userManager;
        private IWebHostEnvironment  _env;
        public PostController(ApplicationDbContext context, UserManager<AppUsers> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        [HttpGet("GetAllPost")]
        public async Task<IActionResult> GetAllPost()
        {
            return Ok(await _context.postModelD.ToListAsync());
        }

        [HttpGet("GetPostById/{id}")]
        public async Task<IActionResult> GetPostById([FromRoute]int id)
        {
            return Ok(await _context.postModelD.FindAsync(id));
        }

        [HttpGet("GetPostUser")]
        public async Task<IActionResult> GetPostUser()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var userId = user.Id;
            return Ok(await _context.postModelD.Where(x=>x.appUserId == userId).ToListAsync());
        }

        [HttpGet("GetOnePost")]
        public async Task<IActionResult> GetOnePost(int id)
        {
            return Ok(await _context.postModelD.FindAsync(id));
        }

   
        [HttpPost("AddPost")]
        [Authorize]
        public async Task<IActionResult> AddPost([FromForm]PostModel post)
        {
            if (ModelState.IsValid)
            {
                post.photoName = await ImageUpload.ImageUploadHandle(post, _env);
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                post.appUserId = user.Id;
                await _context.postModelD.AddAsync(post);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }
    }
}
