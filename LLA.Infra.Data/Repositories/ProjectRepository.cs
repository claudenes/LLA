using LLA.Domain.Entities;
using LLA.Domain.Interfaces;
using LLA.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LLA.Infra.Data.Repositories;

public class ProjectRepository : IProjectRepository
{
    private ApplicationDbContext _projectContext;
    public ProjectRepository(ApplicationDbContext context)
    {
        _projectContext = context;
    }

    public async Task<Projeto> CreateAsync(Projeto project)
    {
        _projectContext.Add(project);
        await _projectContext.SaveChangesAsync();
        return project;
    }
    public async Task<Projeto> GetByIdAsync(int? id)
    {
        return await _projectContext.Projects.SingleOrDefaultAsync(p => p.Id == id.Value);
    }

    public async Task<IEnumerable<Projeto>> GetProjectsAsync()
    {
        return await _projectContext.Projects.ToListAsync();
    }

    public async Task<Projeto> RemoveAsync(Projeto project)
    {
        _projectContext.Remove(project);
        await _projectContext.SaveChangesAsync();
        return project;
    }

    public async Task<Projeto> UpdateAsync(Projeto project)
    {
        _projectContext.Update(project);
        await _projectContext.SaveChangesAsync();
        return project;
    }
}
