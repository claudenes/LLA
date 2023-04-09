using LLA.Domain.Entities;
using MediatR;

namespace LLA.Application.Projects.Commands;

public class ProjectRemoveCommand : IRequest<Projeto>
{
    public int Id { get; set; }
    public ProjectRemoveCommand(int id)
    {
        Id = id;
    }
}
