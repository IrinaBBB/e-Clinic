using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace e_Clinic.DataAccess.Entities
{
    public class Visit
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
