using Microsoft.EntityFrameworkCore;
using Portfolio.DB_Context;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Repository
{
    public class SkillRepository:Iskill
    {
        private readonly AppDbContext context;

        public SkillRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<skill> AddSkillAsync(skill newSkill)
        {
            await context.skill.AddAsync(newSkill);
            await context.SaveChangesAsync();
            return newSkill;
        }



        public async Task<bool> DeleteSkillAsync(int id)
        {
            var skill = await context.skill.FindAsync(id);
            if (skill == null)
            {
                return false; // Skill not found
            }
            context.skill.Remove(skill);
            await context.SaveChangesAsync();
            return true; // Skill deleted successfully
        }

        public async Task<IEnumerable<skill>> GetAllSkillsAsync()
        {
           var skills = await context.skill.ToListAsync();
            return skills;
        }

        public async Task<skill> GetSkillByIdAsync(int id)
        {
            var skill = await context.skill.FindAsync(id);
            if (skill == null)
            {
                throw new KeyNotFoundException($"Skill with ID {id} not found.");
            }
            return skill;
        }

        public async Task<skill> UpdateSkillAsync(skill updatedSkill)
        {
            var existingSkill = await context.skill.FindAsync(updatedSkill.id);
            if (existingSkill == null)
            {
                throw new KeyNotFoundException($"Skill with ID {updatedSkill.id} not found.");
            }
            existingSkill.skills = updatedSkill.skills; 
            context.skill.Update(existingSkill);
            await context.SaveChangesAsync();
            return existingSkill;
        }

      
    }
}
