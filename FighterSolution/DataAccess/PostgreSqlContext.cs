using Microsoft.EntityFrameworkCore;
using FighterSolution.Models;  

namespace FighterSolution.DataAccess
{
    public class PostgreSqlContext: DbContext  
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)  
        {  
        }  
  
        public DbSet<Fighter> Fighters { get; set; }  
  
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        }  
  
        public override int SaveChanges()  
        {  
            ChangeTracker.DetectChanges();  
            return base.SaveChanges();  
        }  
    }
}