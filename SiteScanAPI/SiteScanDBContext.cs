using Microsoft.EntityFrameworkCore;
using SiteScanAPI.Model;

namespace SiteScanAPI
{
    public class SiteScanDBContext : DbContext
    {
        public SiteScanDBContext()
        {
        }
        public SiteScanDBContext(DbContextOptions<SiteScanDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
