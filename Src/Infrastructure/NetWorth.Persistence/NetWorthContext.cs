using Microsoft.EntityFrameworkCore; 
using NetWorth.Domain.Entities;

namespace NetWorth.Persistence {     
    public class NetWorthContext : DbContext     
    {         
        public NetWorthContext(DbContextOptions<NetWorthContext> options)                            
            : base(options)         
        {         
        }       
        public DbSet<User> Users { get; set; }   

        public DbSet<NWFactor> Factors { get; set; }
   } 
}