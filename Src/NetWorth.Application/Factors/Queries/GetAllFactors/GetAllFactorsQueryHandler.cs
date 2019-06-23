using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetWorth.Persistence;
using NetWorth.Domain.Entities;

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
            var assets = await _context.Factors.OfType<Asset>().OrderBy(p => p.Name).ToListAsync(cancellationToken);
            var liabilities = await _context.Factors.OfType<Liability>().OrderBy(p => p.Name).ToListAsync(cancellationToken);

            var model = new FactorsListViewModel
            {
                Assets = _mapper.Map<IEnumerable<FactorDto>>(assets),
                Liabilities = _mapper.Map<IEnumerable<FactorDto>>(liabilities),
                CreateEnabled = true
            };

            return model;
        }
    }
}