using LLA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLA.Domain.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Projeto>> GetProjectsAsync();
    Task<Projeto> GetByIdAsync(int? id);
    Task<Projeto> CreateAsync(Projeto project);
    Task<Projeto> UpdateAsync(Projeto project);
    Task<Projeto> RemoveAsync(Projeto project);
}
