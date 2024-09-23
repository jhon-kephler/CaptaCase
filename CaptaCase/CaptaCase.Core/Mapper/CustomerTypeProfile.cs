using AutoMapper;
using CaptaCase.Core.Schema.CustomerTypeSchema.Request;
using CaptaCase.Core.Schema.CustomerTypeSchema.Response;
using CaptaCase.Domain.Entities;

namespace CaptaCase.Core.Mapper
{
    public class CustomerTypeProfile : Profile
    {
        public CustomerTypeProfile()
        {
            CreateMap<CustomerType, CustomerTypeResponse>()
                .ForMember(dest => dest.TypeId, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Type, src => src.MapFrom(x => x.Type));

            CreateMap<SaveCustomerTypeRequest, CustomerType>()
                .ForMember(dest => dest.Type, src => src.MapFrom(x => x.Type));

            CreateMap<UpdateCustomerTypeRequest, CustomerType>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.TypeId))
                .ForMember(dest => dest.Type, src => src.MapFrom(x => x.Type));
        }
    }
}
