using MediatR;

namespace NetWorth.Application.Factors.Commands.UpdateFactor
{
    public class UpdateFactorCommand : IRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public double CurrentValue { get; set; }

        public bool HasInterest { get; set; }

        public double InterestRate { get; set; } 

        public int Type { get; set; }  

        public long UserID { get; set; }

        public bool IsAsset { get; set; }
    }
}