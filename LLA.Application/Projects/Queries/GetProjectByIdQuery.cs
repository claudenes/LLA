using LLA.Domain.Entities;
using MediatR;

namespace LLA.Application.Projects.Queries;

public class GetProjectByIdQuery : IRequest<Projeto>
{
    public int Id { get; set; }
    public GetProjectByIdQuery(int id)
    {
        Id = id;
    }
}
