using LLA.Application.Projects.Commands;
using LLA.Domain.Entities;
using LLA.Domain.Interfaces;
using MediatR;

namespace LLA.Application.Projects.Handlers;

public class ProjectCreateCommandHandler : IRequestHandler<ProjectCreateCommand, Projeto>
{
    private readonly IProjectRepository _projectRepository;
    public ProjectCreateCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    public async Task<Projeto> Handle(ProjectCreateCommand request,
        CancellationToken cancellationToken)
    {
        var projeto = new Projeto(request.Titulo, request.Descricao, request.DtCriacao);

        if (projeto == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            return await _projectRepository.CreateAsync(projeto);
        }
    }
}
