using LLA.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace LLA.Application.Projects.Queries;

public class GetProjectQuery : IRequest<IEnumerable<Projeto>>
{
}
