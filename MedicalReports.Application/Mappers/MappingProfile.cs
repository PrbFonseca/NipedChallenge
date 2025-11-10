using AutoMapper;
using MedicalReports.Application.Dtos;
using MedicalReports.Core.Entities;

namespace MedicalReports.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Guideline, GuidelineDto>()
                .ForMember(dest => dest.MatchingType, opt => opt.MapFrom(src => src.MatchingType.ToString()));

            CreateMap<GuidelineItem, GuidelineItemDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<Patient, PatientDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));

            CreateMap<PatientBloodWork, PatientBloodWorkDto>();
            CreateMap<PatientQuestionnaire, PatientQuestionnaireDto>();
        }
    }
}
