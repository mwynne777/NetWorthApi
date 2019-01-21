using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetWorth.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace NetWorth.Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, UsersListViewModel>
    {
        private readonly NetWorthContext _context;
        private readonly IMapper _mapper;

        public GetUsersListQueryHandler(NetWorthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UsersListViewModel> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            return new UsersListViewModel
            {
                Users = await _context.Users.ProjectTo<UserLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}