using formCreator.Models;
using Microsoft.EntityFrameworkCore;

namespace formCreator.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
