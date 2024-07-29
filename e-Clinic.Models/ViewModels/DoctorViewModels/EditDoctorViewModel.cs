using System.ComponentModel.DataAnnotations;

namespace e_Clinic.Models.ViewModels.Patient
{
    public class EditDoctorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; } 

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Gender")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Contact Number")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Emergency Contact")]
        public string? EmergencyContact { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Licence Number")]
        public string? LicenseNumber { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; } 

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Speciality")]
        public string? Specialty { get; set; }
    }
}
