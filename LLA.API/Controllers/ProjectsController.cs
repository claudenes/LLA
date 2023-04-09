using LLA.Application.DTOs;
using LLA.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LLA.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDTO>>> Get()
    {
        var projects = await _projectService.GetProjects();
        if (projects == null)
        {
            return NotFound("Projects not found");
        }
        return Ok(projects);
    }

    [HttpGet("{id}", Name = "GetProjects")]
    public async Task<ActionResult<ProjectDTO>> Get(int id)
    {
        var project = await _projectService.GetById(id);
        if (project == null)
        {
            return NotFound("Projects not found");
        }
        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProjectDTO projectDto)
    {
        if (projectDto == null)
            return BadRequest("Data Invalid");

        await _projectService.Add(projectDto);

        return new CreatedAtRouteResult("GetProjects",
            new { id = projectDto.Id }, projectDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProjectDTO projectDto)
    {
        if (id != projectDto.Id)
        {
            return BadRequest("Data invalid");
        }

        if (projectDto == null)
            return BadRequest("Data invalid");

        await _projectService.Update(projectDto);

        return Ok(projectDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProjectDTO>> Delete(int id)
    {
        var projectDto = await _projectService.GetById(id);

        if (projectDto == null)
        {
            return NotFound("Project not found");
        }

        await _projectService.Remove(id);

        return Ok(projectDto);
    }
}
