using Portfolio.Models;

namespace Portfolio.Repository_Interface
{
    public interface IAboutRepository
    {

        Task<IEnumerable<About_Me>> GetAllAsync();
        Task<About_Me> GetByIdAsync(int id);
        Task<About_Me> CreateAsync(About_Me model);
        Task<About_Me> UpdateAsync(About_Me model);
        Task<bool> DeleteAsync(int id);
    }
}
