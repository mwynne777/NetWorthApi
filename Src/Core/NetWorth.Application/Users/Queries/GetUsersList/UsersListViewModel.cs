using System.Collections.Generic;

namespace NetWorth.Application.Users.Queries.GetUsersList
{
    public class UsersListViewModel
    {
        public IList<UserLookupModel> Users { get; set; }
    }
}