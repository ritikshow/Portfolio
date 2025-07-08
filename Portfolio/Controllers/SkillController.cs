using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Controllers
{
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
        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
             await iskill.GetAllSkillsAsync(); 
            // Logic to retrieve all skills
            return Ok(); // Return the list of skills
        }
        // GET: api/skill/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            await iskill.GetSkillByIdAsync(id);
            return Ok(); // Return the skill
        }

        // POST: api/skill
        [HttpPost]

        public async Task<IActionResult> AddSkill([FromBody] Models.skill newSkill)
        {
            if (newSkill == null)
            {
                return BadRequest("Skill cannot be null");
            }
            await iskill.AddSkillAsync(newSkill);
            return Ok(newSkill); 
        }
        // PUT: api/skill/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] skill updatedSkill)
        {
            if (updatedSkill == null || updatedSkill.id != id)
            {
                return BadRequest("Invalid skill data");
            }
            await iskill.UpdateSkillAsync(updatedSkill);
            return NoContent(); 
        }

        // DELETE: api/skill/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            await iskill.DeleteSkillAsync(id);  
            return NoContent(); 
        }


    }
}
