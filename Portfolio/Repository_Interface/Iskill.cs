using Portfolio.Models;

namespace Portfolio.Repository_Interface
{
    public interface Iskill
    {
        // Get all skills
        Task<IEnumerable<skill>> GetAllSkillsAsync();
        // Get a skill by ID
        Task<skill> GetSkillByIdAsync(int id);
        // Add a new skill
        Task<skill> AddSkillAsync(skill newSkill);
        // Update an existing skill
        Task<skill> UpdateSkillAsync(skill updatedSkill);
        // Delete a skill
        Task<bool> DeleteSkillAsync(int id);
    }
}
