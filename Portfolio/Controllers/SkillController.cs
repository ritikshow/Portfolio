using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly Iskill iskill;

        public SkillController( Iskill iskill)
        {
            this.iskill = iskill;
            // Initialize any required services or repositories here
        }
        // GET: api/skill
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            Service<IEnumerable<skill>> res = new ();
            res.Data = await iskill.GetAllSkillsAsync(); // Call the repository to get all skills
            res.Message = "Skills retrieved successfully";
            res.Success = true; // Indicate success 
            // Logic to retrieve all skills
            return Ok(res); // Return the list of skills
        }
        // GET: api/skill/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            Service<skill> res = new ();
            res.Data = await iskill.GetSkillByIdAsync(id); // Call the repository to get skill by ID
            if (res.Data == null)
            {
                return NotFound($"Skill with ID {id} not found");
            }
            res.Message = "Skill retrieved successfully";
            return Ok(res); // Return the skill
        }

        // POST: api/skill
        [HttpPost]

        public async Task<IActionResult> AddSkill([FromBody] Models.skill newSkill)
        {
            Service<skill> res = new();
            if (newSkill == null)
            {
                return BadRequest("Skill cannot be null");
            }

            res.Data = await iskill.AddSkillAsync(newSkill);
            if (res.Data == null)
            {
                return BadRequest("Failed to add skill");
            }
            res.Message = "Skill added successfully";
            res.Success = true; // Indicate success
            return Ok(res); 
        }
        // PUT: api/skill/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] skill updatedSkill)
        {
            Service<skill> res = new();
            if (updatedSkill == null || updatedSkill.id != id)
            {
                return BadRequest("Invalid skill data");
            }

            res.Data= await iskill.UpdateSkillAsync(updatedSkill);
            if (res.Data == null)
            {
                return NotFound($"Skill with ID {id} not found");
            }
            res.Message = "Skill updated successfully";
            res.Success = true; // Indicate success
            return Ok(res); 
        }

        // DELETE: api/skill/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            Service<bool> res = new();
            res.Data = await iskill.DeleteSkillAsync(id);
            res.Message = "Skill deleted successfully";
            res.Success = true; // Indicate success
            if (!res.Data)
            {
                return NotFound($"Skill with ID {id} not found");
            }
           
            return Ok(res); 
        }


    }
}
