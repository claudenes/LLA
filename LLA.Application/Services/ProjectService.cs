using AutoMapper;
using LLA.Application.DTOs;
using LLA.Application.Interfaces;
using LLA.Application.Projects.Commands;
using LLA.Application.Projects.Queries;
using MediatR;

namespace LLA.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public ProjectService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ProjectDTO>> GetProjects()
    {
        var projectsQuery = new GetProjectQuery();

        if (projectsQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(projectsQuery);

        return _mapper.Map<IEnumerable<ProjectDTO>>(result);
    }

    public async Task<ProjectDTO> GetById(int? id)
    {
        var projectByIdQuery = new GetProjectByIdQuery(id.Value);

        if (projectByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var result = await _mediator.Send(projectByIdQuery);

        return _mapper.Map<ProjectDTO>(result);
    }

    public async Task Add(ProjectDTO projectDTO)
    {
        var projectCreateCommand = _mapper.Map<ProjectCreateCommand>(projectDTO);
        await _mediator.Send(projectCreateCommand);
    }

    public async Task Update(ProjectDTO projectDTO)
    {
        var projectUpdateCommand = _mapper.Map<ProjectUpdateCommand>(projectDTO);
        await _mediator.Send(projectUpdateCommand);
    }

    public async Task Remove(int? id)
    {
        var projectRemoveCommand = new ProjectRemoveCommand(id.Value);
        if (projectRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(projectRemoveCommand);
    }
}
