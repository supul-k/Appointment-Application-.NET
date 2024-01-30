using System.ComponentModel.DataAnnotations;

namespace Project.DTO
{
    public class AppointmentScheduleRequestDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string AppoinmentId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
    }
}
