using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutMeController : ControllerBase
    {
        private readonly IAboutRepository _repo;
        private readonly IFileUploadService _fileService;

        public AboutMeController(IAboutRepository repo, IFileUploadService fileService)
        {
            _repo = repo;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] About_Me model)
        {
            if (model.Image != null)
                model.ImageFile = await _fileService.SaveImageAsync(model.Image);

            if (model.Resume != null)
                model.ResumeFile = await _fileService.SaveResumeAsync(model.Resume);

            model.CreatedAt = DateTime.UtcNow;
            model.LastModified = DateTime.UtcNow;

            var result = await _repo.CreateAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] About_Me model)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            model.ImageFile = model.Image != null
                ? await _fileService.SaveImageAsync(model.Image)
                : existing.ImageFile;

            model.ResumeFile = model.Resume != null
                ? await _fileService.SaveResumeAsync(model.Resume)
                : existing.ResumeFile;

            model.Id = id;
            model.CreatedAt = existing.CreatedAt;
            model.LastModified = DateTime.UtcNow;

            var updated = await _repo.UpdateAsync(model);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
