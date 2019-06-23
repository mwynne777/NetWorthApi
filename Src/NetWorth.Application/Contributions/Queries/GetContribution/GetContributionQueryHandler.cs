using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetWorth.Application.Exceptions;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetWorth.Application.Contributions.Queries.GetContribution
{
    public class GetContributionQueryHandler : MediatR.IRequestHandler<GetContributionQuery, ContributionViewModel>
    {
        private readonly NetWorthContext _context;
        private readonly IMapper _mapper;

        public GetContributionQueryHandler(NetWorthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ContributionViewModel> Handle(GetContributionQuery request, CancellationToken cancellationToken)
        {
            var contribution = _mapper.Map<ContributionViewModel>(await _context
                .Contributions.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (contribution == null)
            {
                throw new NotFoundException(nameof(Contribution), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            contribution.EditEnabled = true;
            contribution.DeleteEnabled = false;

            return contribution;
        }
    }
}