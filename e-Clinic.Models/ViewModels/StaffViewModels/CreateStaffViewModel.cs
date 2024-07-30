using System.ComponentModel.DataAnnotations;

namespace e_Clinic.Models.ViewModels.StaffViewModels
{
    public class CreateStaffViewModel
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
        public DateTime? DateOfBirth { get; set; } = new DateTime(2000, 1, 1);

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

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Role")]
        public string? Role { get; set; }

        [Required(ErrorMessage = "*required")]
        [Display(Name = "Joining Date")]
        public DateTime JoiningDate { get; set; } = DateTime.Now;
    }
}
