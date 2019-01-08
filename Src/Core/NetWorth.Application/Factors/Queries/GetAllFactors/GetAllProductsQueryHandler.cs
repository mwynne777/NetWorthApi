using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetWorth.Persistence;

namespace NetWorth.Application.Factors.Queries.GetAllFactors
{
    public class GetAllFactorsQueryHandler : IRequestHandler<GetAllFactorsQuery, FactorsListViewModel>
    {
        private readonly NetWorthContext _context;
        private readonly IMapper _mapper;

        public GetAllFactorsQueryHandler(NetWorthContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FactorsListViewModel> Handle(GetAllFactorsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Set view model state based on user permissions.
            var products = await _context.Factors.OrderBy(p => p.Name).ToListAsync(cancellationToken);

            var model = new FactorsListViewModel
            {
                Products = _mapper.Map<IEnumerable<FactorDto>>(products),
                CreateEnabled = true
            };

            return model;
        }
    }
}