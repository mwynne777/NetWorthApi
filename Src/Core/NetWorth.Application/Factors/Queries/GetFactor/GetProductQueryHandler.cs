using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetWorth.Application.Exceptions;
using NetWorth.Domain.Entities;
using NetWorth.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetWorth.Application.Factors.Queries.GetFactor
{
    public class GetFactorQueryHandler : MediatR.IRequestHandler<GetFactorQuery, FactorViewModel>
    {
        private readonly NetWorthContext _context;
        private readonly IMapper _mapper;

        public GetFactorQueryHandler(NetWorthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FactorViewModel> Handle(GetFactorQuery request, CancellationToken cancellationToken)
        {
            var factor = _mapper.Map<FactorViewModel>(await _context
                .Factors.Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (factor == null)
            {
                throw new NotFoundException(nameof(NWFactor), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            factor.EditEnabled = true;
            factor.DeleteEnabled = false;

            return factor;
        }
    }
}