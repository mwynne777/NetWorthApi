using System;
using System.Collections.Generic;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.Users.Queries.GetNetWorth
{
    public class NetWorthDetailModel
    {
        public long UserID { get; set; }
        public Dictionary<DateTime, double> DateToNetWorthDict { get; set; }
    }
}