using Microsoft.EntityFrameworkCore;
using Portfolio.DB_Context;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Repository
{
    public class contactRepository : Icontact

    {
        public readonly AppDbContext _context;
        public contactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Contanct> CreateAsync(Contanct project)
        {
            var data = await _context.Contancts.AddAsync(project);
            await _context.SaveChangesAsync();
            return data.Entity;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var data = _context.Contancts.Find(id);
            if (data == null) return Task.FromResult(false);
            _context.Contancts.Remove(data);
            _context.SaveChanges();
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<Contanct>> GetAllAsync()
        {
            var data = await _context.Contancts.ToListAsync();
            return data;
        }
    }
}
