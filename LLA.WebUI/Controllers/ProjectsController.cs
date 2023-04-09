using LLA.Application.DTOs;
using LLA.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LLA.WebUI.Controllers;

public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;
    private readonly IWebHostEnvironment _environment;

    public ProjectsController(IProjectService projectService, IWebHostEnvironment environment)
    {
        _projectService = projectService;
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetProjects();
        return View(projects);
    }



    [HttpPost(), ActionName("Create")]
    public async Task<IActionResult> Create(ProjectDTO projectDto)
    {
        if (ModelState.IsValid)
        {
            await _projectService.Add(projectDto);
            return RedirectToAction(nameof(Index));
        }
       
        return View(projectDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var projectDto = await _projectService.GetById(id);

        if (projectDto == null) return NotFound();

        return View(projectDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProjectDTO projectDto)
    {
        if (ModelState.IsValid)
        {
            await _projectService.Update(projectDto);
            return RedirectToAction(nameof(Index));
        }
        return View(projectDto);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var projectdto = await _projectService.GetById(id);

        if (projectdto == null) return NotFound();

        return View(projectdto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _projectService.Remove(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var projectDto = await _projectService.GetById(id);

        if (projectDto == null) return NotFound();
        var wwwroot = _environment.WebRootPath;
      
        return View(projectDto);
    }
}
