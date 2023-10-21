using AutoMapper;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.Patient;
using e_Clinic.Repository.Mapping.Resolvers;

namespace e_Clinic.Repository.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // PATIENT //
            CreateMap<Patient, PatientViewModel>()
                .ForMember(dest => dest.Age, opt =>
                    opt.MapFrom<AgeResolver>());

            CreateMap<PatientViewModel, Patient>();
        }
    }
}