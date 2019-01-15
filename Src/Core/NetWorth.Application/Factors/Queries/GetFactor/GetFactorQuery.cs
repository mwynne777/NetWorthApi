using MediatR;

namespace NetWorth.Application.Factors.Queries.GetFactor
{
    public class GetFactorQuery : IRequest<FactorViewModel>
    {
        public long Id { get; set; }
    }
}