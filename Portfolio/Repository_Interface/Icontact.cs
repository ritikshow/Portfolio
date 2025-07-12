using Portfolio.Models;

namespace Portfolio.Repository_Interface
{
    public interface Icontact
    {
        Task<IEnumerable<Contanct>> GetAllAsync();
        //Task<Contanct> GetByIdAsync(int id);
        Task<Contanct> CreateAsync(Contanct contanct);
        Task<bool> DeleteAsync(int id);
    }
}
