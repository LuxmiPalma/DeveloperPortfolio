using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsApi.Data;
using ProjectsApi.Models;
using ProjectsApi.Models.DTO;

namespace ProjectsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("dto")]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProjectsDTO()
        {
            var projects = await _context.Projects
                .Include(p => p.Technologies)
                .ThenInclude(ts => ts.TechIcon)
                .ToListAsync();

            var projectDTOs = projects.Select(p => new ProjectDTO
            {
                ProjectImg = p.ProjectImg,
                Name = p.Name,
                TechStack = p.TechStack,
                Date = p.Date,
                Description = p.Description,
                GitHubUrl = p.GitHubUrl,
                LiveDemoUrl = p.LiveDemoUrl,
                Technologies = p.Technologies.Select(t => new TechIconDTO
                {
                    Technology = t.TechIcon.Technology,
                    Url = t.TechIcon.Url
                }).ToList()
            }).ToList();

            return Ok(projectDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.Technologies)
                .ThenInclude(t => t.TechIcon)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
                return NotFound();

            return project;
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
                return BadRequest();

            _context.Entry(project).State = EntityState.Modified;

            // Update TechStack manually if needed

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.Technologies)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
                return NotFound();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}
