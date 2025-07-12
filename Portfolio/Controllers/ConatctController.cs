using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConatctController : ControllerBase
    {
        public readonly Icontact _contactRepository;
        public ConatctController(Icontact contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/Conatct
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            Service<IEnumerable<Contanct>> res = new();
            res.Data = await _contactRepository.GetAllAsync(); // Call the repository to get all contacts
            res.Message = "Contacts retrieved successfully";
            res.Success = true; // Indicate success
            return Ok(res);
        }

        // POST: api/Conatct
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contanct contact)
        {
            Service<Contanct> res = new();
            if (contact == null)
            {
                return BadRequest("Contact cannot be null");
            }
            res.Data = await _contactRepository.CreateAsync(contact);
            if (res.Data == null)
            {
                return BadRequest("Failed to create contact");
            }
            res.Message = "Contact created successfully";
            res.Success = true;
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            Service<bool> res = new();
            res.Success = await _contactRepository.DeleteAsync(id);
            if (!res.Success)
            {
                return NotFound($"Contact with ID {id} not found");
            }
            res.Message = "Contact deleted successfully";
            return Ok(res);
        }
    }
}
