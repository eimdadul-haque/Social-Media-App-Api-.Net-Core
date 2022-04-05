using Microsoft.AspNetCore.Identity;

namespace Social_Media_App_Api_.Net_Core.Models
{
    public class AppUsers : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string photoName { get; set; }
    }
}
