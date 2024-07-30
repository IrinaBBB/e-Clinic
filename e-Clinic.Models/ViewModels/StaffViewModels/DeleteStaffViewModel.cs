using System.ComponentModel.DataAnnotations;

namespace e_Clinic.Models.ViewModels.StaffViewModels
{
    public class DeleteStaffViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string? Gender { get; set; }

        [Display(Name = "Contact Number")]
        public string? ContactNumber { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }
    }
}
