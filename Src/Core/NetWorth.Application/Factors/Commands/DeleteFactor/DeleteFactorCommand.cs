using MediatR;

namespace NetWorth.Application.Factors.Commands.DeleteFactor
{
    public class DeleteFactorCommand : IRequest
    {
        public long Id { get; set; }

        public bool IsAsset { get; set; }
    }
}