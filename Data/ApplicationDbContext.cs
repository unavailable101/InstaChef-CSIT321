using InstaChef.Models;
using Microsoft.EntityFrameworkCore;

namespace InstaChef.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
    }
}
