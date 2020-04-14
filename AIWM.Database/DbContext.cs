using AIWM.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Security.Permissions;
using System.Security.Principal;

namespace AIWM.Database
{
    public class DatabaseContext : DbContext
    {
        private const string connectionString = "User Id=c##sariel;Password=tiger;Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = orcl)))";

        public DbSet<User> Users { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
        }

    }
}
