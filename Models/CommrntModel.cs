using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Social_Media_App_Api_.Net_Core.Models
{
    public class CommrntModel
    {
        public int Id { get; set; }

        [Required]
        public string? commentBody { get; set; } 

        public int PostModelId { get; set; }
        
        [ForeignKey("PostModelId")]
        public PostModel? PostModel { get; set; }

        public string? appUserId { get; set; }
        [ForeignKey("appUserId")]
        public AppUsers? appUser { get; set; }
    }
}
