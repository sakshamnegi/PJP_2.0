using Microsoft.EntityFrameworkCore;
using DateTimeCalculator.Models;

namespace DateTimeCalculator.Data
{
    
    public class RecordsDbContext : DbContext
    {

        public RecordsDbContext(DbContextOptions<RecordsDbContext> options) : base(options)
        {

        }
        public DbSet<OutputEntity> Records { get; set; }

        //auto increment Id 
        protected override void OnModelCreating(ModelBuilder modelBuilder){
    modelBuilder.Entity<OutputEntity>()
        .Property(o => o.Id)
        .ValueGeneratedOnAdd();
 }
    }
}