using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class ContactUsModel
    {
        [Key]
        [Column("ContactId", TypeName = "nvarchar(36)")]
        public string ContactId { get; set; }

        [Column("ContactNumber", TypeName = "nvarchar(36)")]
        public string ContactNumber { get; set; }

        [Column("Email", TypeName = "nvarchar(36)")]
        public string Email { get; set; }

        [Column("Message", TypeName = "text")]
        public string Message { get; set; }

        [Column("MessageType", TypeName = "nvarchar(36)")]
        public string MessageType { get; set; }
    }
}
