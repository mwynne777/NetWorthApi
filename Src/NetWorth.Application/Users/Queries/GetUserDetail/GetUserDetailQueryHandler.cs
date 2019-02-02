using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            var entity = await _context.Users
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            var assets = await _context.Assets.Where(a => a.UserID == request.Id).ToListAsync();
            var liabilities = await _context.Liabilities.Where(l => l.UserID == request.Id).ToListAsync();

            foreach(Asset a in assets)
                entity.Assets.Add(a);
            foreach(Liability l in liabilities)
                entity.Liabilities.Add(l);

            return _mapper.Map<UserDetailModel>(entity);
        }
    }
}