using System;
using System.Linq.Expressions;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Users.Queries.GetUserDetail
{
    public class UserDetailModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static Expression<Func<User, UserDetailModel>> Projection
        {
            get
            {
                return customer => new UserDetailModel
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    UserName = customer.UserName,
                    Password = customer.Password,
                };
            }
        }

        public static UserDetailModel Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}