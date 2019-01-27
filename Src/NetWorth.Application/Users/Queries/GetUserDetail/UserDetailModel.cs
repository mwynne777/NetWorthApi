using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NetWorth.Application.Factors.Queries.GetAllFactors;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Users.Queries.GetUserDetail
{
    public class UserDetailModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double NetWorth {get; set; }
        public IEnumerable<FactorDto> Assets { get; set; } 
        public IEnumerable<FactorDto> Liabilities { get; set; }

        public static Expression<Func<User, UserDetailModel>> Projection
        {
            get
            {
                return user => new UserDetailModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
        }

        public static UserDetailModel Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}