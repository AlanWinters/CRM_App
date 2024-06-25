using CRM_App.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM_App.Library
{
    public class AppDbContext : DbContext
    {
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyModel>();
            modelBuilder.Entity<ContactModel>().Navigation(nameof(ContactModel.Company)).AutoInclude();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Data Source=crm.db", MySqlServerVersion.LatestSupportedServerVersion);
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
