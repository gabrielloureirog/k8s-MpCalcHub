using AutoMapper;
using DTO = MPCalcHub.Application.DataTransferObjects;
using MPCalcHub.Domain.Entities;

namespace MPCalcHub.Application.Mappings;

public class BaseMapper : Profile
{
    public BaseMapper()
    {
        CreateMap<DTO.BaseModel, BaseEntity>()
            .ForMember(dest => dest.Id, opt =>
            {
                opt.Condition(src => src.Id.HasValue == false || src.Id.Value == default);
                opt.UseDestinationValue();
            })
            .ForMember(dest => dest.Id, opt =>
            {
                opt.Condition(src => src.Id.HasValue == true && src.Id.Value != default);
                opt.MapFrom(src => src.Id);
            });
    }
}
