using Microsoft.EntityFrameworkCore;
using DateTimeCalculator_MVC_Webapp.Models;

namespace DateTimeCalculator_MVC_Webapp.Data
{
    
    public class CalculationsDbContext : DbContext
    {

        public CalculationsDbContext(DbContextOptions<CalculationsDbContext> options) : base(options)
        {

        }
        public DbSet<OperationModel> Calculations { get; set; }

        //auto increment Id 
        protected override void OnModelCreating(ModelBuilder modelBuilder){
    modelBuilder.Entity<OperationModel>()
        .Property(o => o.Id)
        .ValueGeneratedOnAdd();
 }
    }
}