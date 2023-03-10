using Microsoft.EntityFrameworkCore;
using MinimalApiStudy.Models;

namespace MinimalApiStudy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Command> Commands => Set<Command>();
    }
}