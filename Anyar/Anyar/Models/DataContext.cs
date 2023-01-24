using Microsoft.EntityFrameworkCore;

namespace Anyar.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){ }

        public DbSet<Team> Teams { get; set; }

    }
}
