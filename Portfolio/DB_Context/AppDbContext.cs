using Microsoft.EntityFrameworkCore;
using Portfolio.Models;
using System.Collections.Generic;

namespace Portfolio.DB_Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<About_Me> About_Mes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
