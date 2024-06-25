using CRM_App.Library.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_App.Models
{
    [Table("Contact")]
    public class ContactModel : BaseModel
    {
        [Required]
        public Title Title { get; set; }

        [Required, StringLength(30)]
        public string Firstname { get; set; }

        [Required, StringLength(30)]
        public string Lastname { get; set; }

        [StringLength(15)]
        public string? Phone { get; set; }

        [StringLength(15)]
        public string? Mobile { get; set; }

        [Required,StringLength(30), EmailAddress]
        public string Email { get; set; }

        [Required]
        public Status Status { get; set; } = Status.Active;

        [Required, ForeignKey(nameof(CompanyId))]
        public CompanyModel Company { get; set; }

        public int CompanyId { get; set; }

    }
}
