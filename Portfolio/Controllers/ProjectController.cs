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
        private readonly IFileUploadService _fileService;

        public ProjectController(IProjectRepository repo, IFileUploadService fileService)
        {
            _repo = repo;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Service<IEnumerable<Project>> res = new();
            res.Data = await _repo.GetAllAsync();
            res.Message = "Projects retrieved successfully.";
            res.Success = true;
            return Ok(res);
        }

        // GET: api/Project/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Service<Project> res = new();
            res.Data = await _repo.GetByIdAsync(id);
            if (res.Data == null)
            {
                res.Message = "Project not found.";
                res.Success = false;
                return NotFound(res);
            }
            res.Message = "Project retrieved successfully.";
            res.Success = true;
            return Ok(res);
        }

        // POST: api/Project
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] Project project)
        {
            Service<Project> res = new();
            if (project.Logo != null)
                project.PLogo = await _fileService.SaveImageAsync(project.Logo);
            if (project.report != null)
                project.reportP = await _fileService.SaveImageAsync(project.report);


            res.Data = await _repo.CreateAsync(project);
            if (res.Data == null)
            {
                res.Message = "Failed to create project.";
                res.Success = false;
                return BadRequest(res);
            }
            res.Message = "Project created successfully.";
            res.Success = true;
            return Ok(res);
        }

        // PUT: api/Project/{id}
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update(int id, [FromForm] Project project)
        {
            Service<Project> res = new();
            //if (id != project.Id) return BadRequest("ID mismatch.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (project.Logo != null)
                project.PLogo = await _fileService.SaveImageAsync(project.Logo);
            if (project.report != null)
                project.reportP = await _fileService.SaveImageAsync(project.report);
            project.LastModified = DateTime.UtcNow;
            project.Id = id;

            res.Data = await _repo.UpdateAsync(project);
            if (res.Data == null)
            {
                res.Message = "Failed to update project.";
                res.Success = false;
                return NotFound(res);
            }
            res.Message = "Project updated successfully.";
            res.Success = true;
            return Ok(res);
        }

        // DELETE: api/Project/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Service<Project> res = new();
            res.Data = await _repo.GetByIdAsync(id);
            if (res.Data == null)
            {
                res.Message = "Project not found.";
                res.Success = false;
                return NotFound(res);
            }
            res.Message = "Project found, proceeding to delete.";
            res.Success = true;
            return Ok(res);
        }
    }
}
