using CRM_App.Library.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM_App.Models
{
    [Table("Company")]
    public  class CompanyModel : BaseModel
    {
        [Required, StringLength(30)]
        public string Company { get; set; }


        [Required, StringLength(30)]
        public string Street { get; set; }

        [Required]
        public string HouseNr { get; set; }

        [Required]
        public int Zipcode { get; set; }

        [Required, StringLength(30)]
        public string City { get; set; }

        [Required]
        public Tags Tag { get; set; }

        public List<ContactModel> Contacts { get; set; } = [];

    }
}
