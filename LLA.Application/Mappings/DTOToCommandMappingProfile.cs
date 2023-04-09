using AutoMapper;
using LLA.Application.DTOs;
using LLA.Application.Projects.Commands;

namespace LLA.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<ProjectDTO, ProjectCreateCommand>();
        CreateMap<ProjectDTO, ProjectUpdateCommand>();
    }
}
