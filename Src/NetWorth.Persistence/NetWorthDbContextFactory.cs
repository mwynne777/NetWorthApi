using Microsoft.EntityFrameworkCore;
using NetWorth.Persistence.Infrastructure;

namespace NetWorth.Persistence
{
    public class NetWorthDbContextFactory : DesignTimeDbContextFactoryBase<NetWorthContext>
    {
        protected override NetWorthContext CreateNewInstance(DbContextOptions<NetWorthContext> options)
        {
            return new NetWorthContext(options);
        }
    }
}