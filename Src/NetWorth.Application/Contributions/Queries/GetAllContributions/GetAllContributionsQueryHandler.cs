using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetWorth.Persistence;

namespace NetWorth.Application.Contributions.Queries.GetAllContributions
{
    public class GetAllContributionsQueryHandler : IRequestHandler<GetAllContributionsQuery, ContributionsListViewModel>
    {
        private readonly NetWorthContext _context;
        private readonly IMapper _mapper;

        public GetAllContributionsQueryHandler(NetWorthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContributionsListViewModel> Handle(GetAllContributionsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Set view model state based on user permissions.
            var contributions = await _context.Contributions.OrderBy(p => p.Name).ToListAsync(cancellationToken);

            var model = new ContributionsListViewModel
            {
                Contributions = _mapper.Map<IEnumerable<ContributionDto>>(contributions)
            };

            return model;
        }
    }
}