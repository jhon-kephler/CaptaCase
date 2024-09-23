using AutoMapper;
using CaptaCase.Core.Schema.CustomerSchema.Request;
using CaptaCase.Core.Schema.CustomerSchema.Response;
using CaptaCase.Domain.Entities;

namespace CaptaCase.Core.Mapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.CPF, src => src.MapFrom(x => x.CPF))
                .ForMember(dest => dest.CustomerTypeId, src => src.MapFrom(x => x.CustomerTypeId))
                .ForMember(dest => dest.CustomerSituationId, src => src.MapFrom(x => x.CustomerSituationId))
                .ForMember(dest => dest.Gender, src => src.MapFrom(x => x.Gender));

            CreateMap<CustomerResponse, Customer>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.CPF, src => src.MapFrom(x => x.CPF))
                .ForMember(dest => dest.CustomerTypeId, src => src.MapFrom(x => x.CustomerTypeId))
                .ForMember(dest => dest.CustomerSituationId, src => src.MapFrom(x => x.CustomerSituationId))
                .ForMember(dest => dest.Gender, src => src.MapFrom(x => x.Gender));

            CreateMap<SaveCustomerRequest, Customer>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.CPF, src => src.MapFrom(x => x.CPF))
                .ForMember(dest => dest.Gender, src => src.MapFrom(x => x.Gender.ToUpper()));

            CreateMap<UpdateCustomerRequest, Customer>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                .ForMember(dest => dest.CPF, src => src.MapFrom(x => x.CPF))
                .ForMember(dest => dest.Gender, src => src.MapFrom(x => x.Gender.ToUpper()));
        }
    }
}
