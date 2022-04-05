using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media_App_Api_.Net_Core.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        
        [Required]
        public string? postBody { get; set; } 

        public string? photoName { get; set; } 

        public List<CommrntModel>? comments { get; set; }

        public string? appUserId { get; set; }

        [ForeignKey("appUserId")]
        public AppUsers? appUser { get; set; }

        [NotMapped]
        public IFormFile? imageFile { get; set; }
    }
}
