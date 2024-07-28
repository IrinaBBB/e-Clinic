using AutoMapper;
using e_Clinic.DataAccess.Entities;
using e_Clinic.Models.ViewModels.Patient;
using e_Clinic.Repository.Mapping.Resolvers;

namespace e_Clinic.Repository.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // PATIENT //
            //CreateMap<Patient, CreatePatientViewModel>()
            //    .ForMember(dest => dest.Age, opt =>
            //        opt.MapFrom<AgeResolver>());

            CreateMap<Patient, Patient>();
            CreateMap<CreatePatientViewModel, Patient>().ReverseMap();
            CreateMap<EditPatientViewModel, Patient>().ReverseMap();

        }
    }
}