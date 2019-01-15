using System;
using System.Collections.Generic;
using System.Linq;
using NetWorth.Domain.Entities;
using NetWorth.Persistence.Infrastructure;

namespace NetWorth.Persistence
{
    public class NetWorthInitializer
    {
        private readonly Dictionary<int, User> Users = new Dictionary<int, User>();
        private readonly Dictionary<int, Asset> Assets = new Dictionary<int, Asset>();
        private readonly Dictionary<int, Liability> Liabilities = new Dictionary<int, Liability>();

        public static void Initialize(NetWorthContext context)
        {
            var initializer = new NetWorthInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(NetWorthContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return; // Db has been seeded
            }

            SeedUsers(context);

            SeedAssets(context);

            SeedLiabilities(context);
        }

        public void SeedUsers(NetWorthContext context)
        {
            var users = new[]
            {
                new User 
                {
                    Id = 1,
                    FirstName = "Michael",
                    LastName = "Wynne",
                    UserName = "mwynne777",
                    Password = "password"
                }
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }

        public void SeedAssets(NetWorthContext context)
        {
            var assets = new[]
            {
                new Asset
                {
                    Id = 1,
                    Name = "Discover Savings",
                    CurrentValue = 2000,
                    HasInterest = true,
                    InterestRate = 1.98,
                    Type = 1,
                    UserID = 1
                }
            };
            context.Assets.AddRange(assets);

            context.SaveChanges();
        }

        public void SeedLiabilities(NetWorthContext context)
        {
            var liabilities = new[]
            {
                new Liability
                {
                    Id = 1,
                    Name = "Student Loan",
                    CurrentValue = 20000,
                    HasInterest = true,
                    InterestRate = 4.3,
                    Type = 1,
                    UserID = 1
                }
            };

            context.Liabilities.AddRange(liabilities);

            context.SaveChanges();
        }

    }
}