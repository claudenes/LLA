using LLA.Application.DTOs;

namespace LLA.Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDTO>> GetProjects();
    Task<ProjectDTO> GetById(int? id);
    Task Add(ProjectDTO projectDto);
    Task Update(ProjectDTO projectDto);
    Task Remove(int? id);
}
