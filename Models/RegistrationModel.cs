using System.ComponentModel.DataAnnotations;

namespace Social_Media_App_Api_.Net_Core.Models
{
    public class RegistrationModel
    {
        [Required]
        public string firstName  { get; set; } = string.Empty;

        [Required]
        public string lastName  { get; set; } = string.Empty;

        [Required]
        public string email  { get; set; } = string.Empty;

        [Required]
        public string password  { get; set; } = string.Empty;

        public string? gendar { get; set; }= string.Empty;

        [Required]
        public string phone { get; set; } = string.Empty;
    }
}
