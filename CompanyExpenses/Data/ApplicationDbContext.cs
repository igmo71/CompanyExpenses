using CompanyExpenses.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyExpenses.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<CompanyStructure> CompanyStructure { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ExpenseItem>().HasKey(e => e.Id);
            builder.Entity<CompanyStructure>().HasKey(e => e.Id);
        }
    }
}
