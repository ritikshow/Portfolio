using Portfolio.Models;

namespace Portfolio.Repository_Interface
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task<Project> CreateAsync(Project project);
        Task<bool> DeleteAsync(int id);
        Task<Project> UpdateAsync(Project project);
    }
}
