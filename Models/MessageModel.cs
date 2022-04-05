using System.ComponentModel.DataAnnotations;

namespace Social_Media_App_Api_.Net_Core.Models
{
    public class MessageModel
    {
        public int Id { get; set; }

        [Required]
        public string? msgBody { get; set; }

        [Required]
        public string? sender { get; set; }

        [Required]
        public string? receiver { get; set; }

        public DateTime when { get; set; } = DateTime.Now;
    }
}
