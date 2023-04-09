using LLA.Application.Projects.Commands;
using LLA.Domain.Entities;
using LLA.Domain.Interfaces;
using MediatR;

namespace LLA.Application.Projects.Handlers;

public class ProjectRemoveCommandHandler : IRequestHandler<ProjectRemoveCommand, Projeto>
{
    private readonly IProjectRepository _projectRepository;
    public ProjectRemoveCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository ?? throw new
            ArgumentNullException(nameof(projectRepository));
    }

    public async Task<Projeto> Handle(ProjectRemoveCommand request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.Id);

        if (project == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            var result = await _projectRepository.RemoveAsync(project);
            return result;
        }
    }
}
