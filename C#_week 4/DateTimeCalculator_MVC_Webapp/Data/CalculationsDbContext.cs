using Microsoft.EntityFrameworkCore;
using DateTimeCalculator_MVC_Webapp.Models;

namespace DateTimeCalculator_MVC_Webapp.Data
{
    
    public class CalculationsDbContext : DbContext
    {

        public CalculationsDbContext(DbContextOptions<CalculationsDbContext> options) : base(options)
        {

        }
        public DbSet<PersistenceModel> Calculations { get; set; }

        //auto increment Id 
        protected override void OnModelCreating(ModelBuilder modelBuilder){
    modelBuilder.Entity<PersistenceModel>()
        .Property(o => o.Id)
        .ValueGeneratedOnAdd();
 }
    }
}