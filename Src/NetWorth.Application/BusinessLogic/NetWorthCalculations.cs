using System;
using System.Collections.Generic;
using NetWorth.Domain.Entities;

namespace NetWorth.Application.BusinessLogic
{
    public class NetWorthCalculations
    {
        public static double GetNetWorth(ICollection<Asset> assets, ICollection<Liability> liabilities)
        {
            double netWorth = 0.0;
            foreach(Asset a in assets)
            {
                netWorth += a.CurrentValue;
            }
            foreach(Liability l in liabilities)
            {
                netWorth -= l.CurrentValue;
            }
            return netWorth;
        }
    }
}