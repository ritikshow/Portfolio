using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectRepository _repo;

        public ProjectController(IProjectRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _repo.GetAllAsync();
            return Ok(projects);
        }

        // GET: api/Project/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _repo.GetByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        // POST: api/Project
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _repo.CreateAsync(project);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Project/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Project project)
        {
            if (id != project.Id) return BadRequest("ID mismatch.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            project.LastModified = DateTime.UtcNow;
            var updated = await _repo.UpdateAsync(project);
            return Ok(updated);
        }

        // DELETE: api/Project/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
