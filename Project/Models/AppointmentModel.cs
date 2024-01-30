using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class AppointmentModel
    {
        [Key]
        [Column("AppointmentId", TypeName = "nvarchar(36)")]
        public string AppointmentId { get; set; }

        [Column("ServiceTypeId", TypeName = "nvarchar(36)")]
        public string ServiceTypeId { get; set; }
        public ServiceTypeModel ServiceType { get; set; }

        [Column("UserId", TypeName = "nvarchar(36)")]
        public string UserId { get; set; }
        public UserModel User { get; set; }

        [Column("SessionCount", TypeName = "int")]
        public int SessionCount { get; set; }

        [Column("FullName", TypeName = "nvarchar(100)")]
        public string name { get; set; }

        [Column("ContactNumber", TypeName = "nvarchar(20)")]
        public string contactNumber { get; set; }

        [Column("Email", TypeName = "varchar(200)")]
        public string Email { get; set; }

        public ICollection<AppointmentSchedule> AppointmentSchedules { get; set; }
    }
}
