using AutoMapper;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;
using e_Clinic.Utility;

namespace e_Clinic.Repository.Mapping.Resolvers
{
    public class AgeResolver : IValueResolver<Patient, CreatePatientViewModel, int>
    {
        public int Resolve(Patient source, CreatePatientViewModel destination, int destMember, ResolutionContext context)
        {
            return UtilFunctions.GetAge(source.DateOfBirth);
        }
    }
}
