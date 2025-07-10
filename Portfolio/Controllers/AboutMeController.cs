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
            Service<IEnumerable<About_Me>> response = new ();

            response.Data = await _repo.GetAllAsync();
            response.Message = "Data retrieved successfully";
            response.Success = true;
            var result = await _repo.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Service<About_Me> response = new();
            response.Data = await _repo.GetByIdAsync(id);
            if (response.Data == null)
            {
                response.Message = "Data not found";
                response.Success = false;
                return NotFound(response);
            }
            response.Message = "Data retrieved successfully";
            response.Success = true;
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] About_Me model)
        {
            Service<About_Me> response = new();
            if (model.Image != null)
                model.ImageFile = await _fileService.SaveImageAsync(model.Image);

            if (model.Resume != null)
                model.ResumeFile = await _fileService.SaveResumeAsync(model.Resume);

            model.CreatedAt = DateTime.UtcNow;
            model.LastModified = DateTime.UtcNow;


             response.Data = await _repo.CreateAsync(model);
             response.Message = "Data created successfully";
             response.Success = true;
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] About_Me model)
        {
            Service<About_Me> response = new();
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();

            // Update only the properties you want to allow changes for
            existing.Name = model.Name;
            existing.Gmail = model.Gmail;
            existing.PhoneNumber = model.PhoneNumber;
            existing.Bio = model.Bio;
            existing.Description = model.Description;
            existing.LastModified = DateTime.UtcNow;

            if (model.Image != null)
                existing.ImageFile = await _fileService.SaveImageAsync(model.Image);

            if (model.Resume != null)
                existing.ResumeFile = await _fileService.SaveResumeAsync(model.Resume);

            response.Data = await _repo.UpdateAsync(existing);
            if (response.Data == null)
            {
                response.Message = "Update failed";
                response.Success = false;
                return NotFound(response);
            }
            response.Message = "Data updated successfully";
            response.Success = true;

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Service<About_Me> response = new();
            var res = await _repo.DeleteAsync(id);
            if (res)
            {
                response.Message = "Delete failed";
                response.Success = false;
                return NotFound(response);
            }
            response.Message = "Data deleted successfully";
            response.Success = true;
            return Ok(response);

        }
    }
}
