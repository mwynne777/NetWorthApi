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
using NetWorth.Common;
using NetWorth.Persistence;

namespace NetWorth.Application.Users.Queries.GetNetWorth
{
    public class GetNetWorthQueryHandler : IRequestHandler<GetNetWorthQuery, double>
    {
        private readonly NetWorthContext _context;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;

        public GetNetWorthQueryHandler(NetWorthContext context, IMapper mapper, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _dateTime = dateTime;
        }

        public async Task<double> Handle(GetNetWorthQuery request, CancellationToken cancellationToken)
        {
            
            User entity = await BuildUser.BuildFromContext(_context, request.Id);

            return entity.GetFutureNetWorth(_dateTime.Now, request.FutureDate);
        }
    }
}