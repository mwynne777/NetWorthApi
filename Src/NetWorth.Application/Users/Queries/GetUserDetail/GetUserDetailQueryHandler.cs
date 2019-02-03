using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetWorth.Application.BusinessLogic;
using NetWorth.Application.Exceptions;
using NetWorth.Application.Factors.Queries.GetAllFactors;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;

namespace NetWorth.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailModel>
    {
        private readonly NetWorthContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(NetWorthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDetailModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            User entity = await BuildUser.BuildFromContext(_context, request.Id);

            return _mapper.Map<UserDetailModel>(entity);
        }
    }
}