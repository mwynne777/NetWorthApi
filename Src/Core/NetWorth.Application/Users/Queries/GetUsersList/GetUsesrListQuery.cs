using MediatR;

namespace NetWorth.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<UsersListViewModel>
    {
    }
}