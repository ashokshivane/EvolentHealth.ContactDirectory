
using System.ComponentModel.DataAnnotations;

namespace Repository.ContactDirectory.BusinessEntities.Models
{
    public class ContactModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
