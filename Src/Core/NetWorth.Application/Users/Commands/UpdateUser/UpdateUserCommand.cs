using MediatR;

namespace NetWorth.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}