using System;
using MediatR;

namespace NetWorth.Application.Users.Queries.GetNetWorth
{
    public class GetNetWorthQuery : IRequest<double>
    {
        public long Id { get; set; }
        public DateTime FutureDate { get; set; }
    }
}