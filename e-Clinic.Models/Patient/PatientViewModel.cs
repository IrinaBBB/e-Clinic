using System.ComponentModel.DataAnnotations;

namespace e_Clinic.Models.Patient
{
    public class PatientViewModel
    {
        public int Id { get; set; }      
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
