using MediatR;

namespace NetWorth.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public long Id { get; set; }
    }
}