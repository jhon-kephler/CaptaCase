using AutoMapper;
using CaptaCase.Core.Schema.CustomerSituationSchema.Request;
using CaptaCase.Core.Schema.CustomerSituationSchema.Response;
using CaptaCase.Domain.Entities;

namespace CaptaCase.Core.Mapper
{
    public class CustomerSituationProfile : Profile
    {
        public CustomerSituationProfile()
        {
            CreateMap<CustomerSituation, CustomerSituationResponse>()
                .ForMember(dest => dest.SituationId, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Situation, src => src.MapFrom(x => x.Situation));


            CreateMap<SaveCustomerSituationRequest, CustomerSituation>()
                .ForMember(dest => dest.Situation, src => src.MapFrom(x => x.Situation));

            CreateMap<UpdateCustomerSituationRequest, CustomerSituation>()
                .ForMember(dest => dest.Situation, src => src.MapFrom(x => x.SituationId))
                .ForMember(dest => dest.Situation, src => src.MapFrom(x => x.Situation));
        }
    }
}
