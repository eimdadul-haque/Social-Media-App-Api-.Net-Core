using Microsoft.EntityFrameworkCore;
using Social_Media_App_Api_.Net_Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Social_Media_App_Api_.Net_Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<PostModel>  postModelD { get; set; }
        public DbSet<CommrntModel> commentD { get; set; }
        public DbSet<MessageModel> messageD { get; set; }
    }

}
