using System.ComponentModel.DataAnnotations;
using e_Clinic.DataAccess.Entities.Identity;

namespace e_Clinic.DataAccess.Entities
{
    public class BaseUser
    {
        public int Id { get; set; }
        //public Guid IdentityId { get; set; }
        //public ApplicationUser? Identity { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;
    }
}
