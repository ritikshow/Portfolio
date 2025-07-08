using Microsoft.EntityFrameworkCore;
using Portfolio.DB_Context;
using Portfolio.Models;
using Portfolio.Repository_Interface;

namespace Portfolio.Repository
{
    public class AboutRepository : IAboutRepository
    {
        private readonly AppDbContext _context;

        public AboutRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<About_Me>> GetAllAsync()
        {
            return await _context.About_Mes.ToListAsync();
        }

        public async Task<About_Me> GetByIdAsync(int id)
        {
            return await _context.About_Mes.FindAsync(id);
        }

        public async Task<About_Me> CreateAsync(About_Me model)
        {
            _context.About_Mes.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _context.About_Mes.FindAsync(id);
            if (data == null) return false;

            _context.About_Mes.Remove(data);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<About_Me> UpdateAsync(About_Me model)
        {
            _context.About_Mes.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }

}
