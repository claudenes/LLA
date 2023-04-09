using LLA.Domain.Entities;
using MediatR;

namespace LLA.Application.Projects.Commands;

public abstract class ProjectCommand : IRequest<Projeto>
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DtCriacao { get; set; }
    
}
