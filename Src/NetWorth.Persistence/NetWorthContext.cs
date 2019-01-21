using Microsoft.EntityFrameworkCore; 
using NetWorth.Domain.Entities;
using NetWorth.Persistence.Configurations;

namespace NetWorth.Persistence {     
    public class NetWorthContext : DbContext     
    {         
        public NetWorthContext(DbContextOptions<NetWorthContext> options)                            
            : base(options)         
        {         
        }       
        public DbSet<User> Users { get; set; }   

        public DbSet<Liability> Liabilities { get; set; }
        public DbSet<Asset> Assets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetWorthContext).Assembly);
        }
   } 
}