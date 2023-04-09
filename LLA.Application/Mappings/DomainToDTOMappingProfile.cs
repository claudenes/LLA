using AutoMapper;
using LLA.Application.DTOs;
using LLA.Domain.Entities;

namespace LLA.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Projeto, ProjectDTO>().ReverseMap();
    }
}
