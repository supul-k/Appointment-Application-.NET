using System.ComponentModel.DataAnnotations;

namespace Project.DTO
{
    public class GeneralResponseDTO
    {
        [Required]
        public bool Status { get; set; }
        [Required]
        public string Message { get; set; }

        public GeneralResponseDTO(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
