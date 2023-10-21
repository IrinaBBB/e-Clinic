using System.Collections;

namespace e_Clinic.DataAccess.Entities
{
    public class Patient : BaseUser
    {
        public ICollection<Visit>? Visits { get; set; }  = new List<Visit>();
    }
}
