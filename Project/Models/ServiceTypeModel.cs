using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ServiceTypeModel
    {
        [Key]
        [Column("TypeId", TypeName = "nvarchar(36)")]
        public string Id { get; set; }

        [Column("TypeName", TypeName = "varchar(50)")]
        public string Name { get; set; }

        [Column("ServiceTypePrice", TypeName = "float")]
        public float Price { get; set; }

        [Column("Description", TypeName = "varchar(200)")]
        public string Description { get; set; }

        public virtual ICollection<AppointmentModel> Appointments { get; set; }
    }
}
