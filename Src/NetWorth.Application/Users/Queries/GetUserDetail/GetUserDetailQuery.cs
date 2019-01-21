using MediatR;

namespace NetWorth.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailModel>
    {
        public long Id { get; set; }
    }
}