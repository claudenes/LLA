using LLA.Application.Projects.Queries;
using LLA.Domain.Entities;
using LLA.Domain.Interfaces;
using MediatR;

namespace LLA.Application.Projects.Handlers;

public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, IEnumerable<Projeto>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Projeto>> Handle(GetProjectQuery request,
        CancellationToken cancellationToken)
    {
        return await _projectRepository.GetProjectsAsync();
    }
}
