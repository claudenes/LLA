using LLA.Application.Projects.Commands;
using LLA.Domain.Entities;
using LLA.Domain.Interfaces;
using MediatR;

namespace LLA.Application.Projects.Handlers;

public class ProjectUpdateCommandHandler : IRequestHandler<ProjectUpdateCommand, Projeto>
{
    private readonly IProjectRepository _projectRepository;
    public ProjectUpdateCommandHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository ??
        throw new ArgumentNullException(nameof(projectRepository));
    }

    public async Task<Projeto> Handle(ProjectUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var projeto = await _projectRepository.GetByIdAsync(request.Id);

        if (projeto == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            projeto.Update(request.Titulo, request.Descricao, request.DtCriacao);

            return await _projectRepository.UpdateAsync(projeto);

        }
    }
}
