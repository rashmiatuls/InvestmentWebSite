using Microsoft.EntityFrameworkCore;
using InvestmentManagement.Entities;
namespace InvestmentManagement.DataLayer
{
    public class InvestmentDbContext : DbContext
    {
        public InvestmentDbContext(DbContextOptions<InvestmentDbContext> options) : base(options)
        {
        }

        public DbSet<Investment> Investments { get; set; }
    }
}
