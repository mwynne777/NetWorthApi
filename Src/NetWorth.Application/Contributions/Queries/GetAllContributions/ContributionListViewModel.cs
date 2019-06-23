using System.Collections.Generic;

namespace NetWorth.Application.Contributions.Queries.GetAllContributions
{
    public class ContributionsListViewModel
    {
        public IEnumerable<ContributionDto> Contributions { get; set; }
    }
}