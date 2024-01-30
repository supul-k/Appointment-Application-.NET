using Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.DTO
{
    public class AppoinmentAddRequestDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string ServiceTypeId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int SessionCount { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public List<DateTime> AppointmentDateTimes { get; set; }
    }
}
