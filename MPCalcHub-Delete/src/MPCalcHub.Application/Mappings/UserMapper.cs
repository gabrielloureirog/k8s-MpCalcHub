using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DTO = MPCalcHub.Application.DataTransferObjects;
using MPCalcHub.Domain.Entities;

namespace MPCalcHub.Application.Mappings;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, DTO.User>()
            .ConstructUsing(src => new DTO.User())
            .ReverseMap()
            .ConstructUsing(src => new User())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.RemovedAt, opt => opt.Ignore())
            .ForMember(dest => dest.RemovedBy, opt => opt.Ignore());

        CreateMap<DTO.BasicUser, User>()
            .ConstructUsing(src => new User());
    }
}