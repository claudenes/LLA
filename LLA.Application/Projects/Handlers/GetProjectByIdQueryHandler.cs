using LLA.Application.Projects.Queries;
using LLA.Domain.Entities;
using LLA.Domain.Interfaces;
using MediatR;

namespace LLA.Application.Projects.Handlers;

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Projeto>
{
    private readonly IProjectRepository _projectRepository;
    public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Projeto> Handle(GetProjectByIdQuery request,
         CancellationToken cancellationToken)
    {
        return await _projectRepository.GetByIdAsync(request.Id);
    }
}
