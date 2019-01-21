using MediatR;

namespace NetWorth.Application.Factors.Queries.GetAllFactors
{
    public class GetAllFactorsQuery : IRequest<FactorsListViewModel>
    {
    }
}