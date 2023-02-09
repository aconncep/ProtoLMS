using Microsoft.EntityFrameworkCore;
using ProtoLMS.Models;

namespace ProtoLMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> User { get; set; }

    }
}
