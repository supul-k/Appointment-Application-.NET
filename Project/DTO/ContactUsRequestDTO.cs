using System.ComponentModel.DataAnnotations;

namespace Project.DTO
{
    public class ContactUsRequestDTO
    {
        [Required]
        public string ContactId { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string MessageType { get; set; }
    }
}
