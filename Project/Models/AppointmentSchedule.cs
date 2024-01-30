using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class AppointmentSchedule
    {
        [Key]
        [Column("AppointmentScheduleId", TypeName = "nvarchar(36)")]
        public string Id { get; set; }

        [Column("AppointmentId", TypeName = "nvarchar(36)")]
        public string AppointmentId { get; set; }
        public AppointmentModel Appointment { get; set; }

        [Column("DateTime", TypeName = "datetime")]
        public DateTime DateTime { get; set; }
    }
}
