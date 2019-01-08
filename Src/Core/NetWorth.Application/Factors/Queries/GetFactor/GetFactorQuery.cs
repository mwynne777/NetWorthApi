using MediatR;

namespace NetWorth.Application.Factors.Queries.GetFactor
{
    public class GetFactorQuery : IRequest<FactorViewModel>
    {
        public int Id { get; set; }
    }
}