using System.Collections.Generic;

namespace NetWorth.Application.Factors.Queries.GetAllFactors
{
    public class FactorsListViewModel
    {
        public IEnumerable<FactorDto> Assets { get; set; }
        public IEnumerable<FactorDto> Liabilities { get; set; }
        public bool CreateEnabled { get; set; }
    }
}