using System.Linq;
using NetWorth.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;
using System.Threading.Tasks;

namespace NetWorth.Application.BusinessLogic
{
    public class BuildUser
    {
        public static async Task<User> BuildFromContext(NetWorthContext context, long userID)
        {
            var entity = await context.Users
                .FindAsync(userID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), userID);
            }

            var assets = await context.Assets.Where(a => a.UserID == userID).ToListAsync();
            var liabilities = await context.Liabilities.Where(l => l.UserID == userID).ToListAsync();

            foreach(Asset a in assets)
                entity.Assets.Add(a);
            foreach(Liability l in liabilities)
                entity.Liabilities.Add(l);

            return entity;
        }
    }
}