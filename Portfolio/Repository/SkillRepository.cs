using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Repository
{
    public class SkillRepository:Iskill
    {
        public SkillRepository() { }

        public async Task<skill> AddSkillAsync(skill newSkill)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteSkillAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<skill>> GetAllSkillsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<skill> GetSkillByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<skill> UpdateSkillAsync(skill updatedSkill)
        {
            throw new NotImplementedException();
        }
    }
}
