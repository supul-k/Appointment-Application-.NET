using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.DTO
{
    public class UserRegisterRequestDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }        
        [Required]
        public string Name { get; set; }       
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
