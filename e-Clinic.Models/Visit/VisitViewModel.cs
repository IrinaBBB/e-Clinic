using System.ComponentModel.DataAnnotations;

namespace e_Clinic.Models.Visit
{
    public class VisitViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int PatientId { get; set; }
    }
}
