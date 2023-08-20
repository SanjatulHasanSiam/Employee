using AjaxModal.Models;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.DataAccess
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile($"appsettings.json")
               .Build();
                var config = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(config ?? string.Empty, ServerVersion.AutoDetect(config));
            }
        }
    }
}
