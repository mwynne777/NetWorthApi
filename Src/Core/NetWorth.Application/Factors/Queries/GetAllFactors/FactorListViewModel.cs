using System.Collections.Generic;

namespace NetWorth.Application.Factors.Queries.GetAllFactors
{
    public class FactorsListViewModel
    {
        public IEnumerable<FactorDto> Products { get; set; }

        public bool CreateEnabled { get; set; }
    }
}