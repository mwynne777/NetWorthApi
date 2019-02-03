using System;
using System.Collections.Generic;
using NetWorth.Domain.Calculations;
using NetWorth.Domain.ValueObjects;

namespace NetWorth.Domain.Entities
{
    public class User
    {
        public User()
        {
            Assets = new HashSet<Asset>();
            Liabilities = new HashSet<Liability>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } //This will depend on sec. implementation
        public string Password { get; set; }

        public ICollection<Asset> Assets { get; private set;}
        public ICollection<Liability> Liabilities { get; private set; }

        public double GetNetWorth()
        {
            double netWorth = 0.0;
            foreach(Asset a in Assets)
            {
                netWorth += a.CurrentValue;
            }
            foreach(Liability l in Liabilities)
            {
                netWorth -= l.CurrentValue;
            }
            return netWorth;
        }

        public double GetFutureNetWorth(DateTime currentDate, DateTime futureDate)
        {
            int months = DateCalculations.GetMonthsBetweenTwoDates(currentDate, futureDate);
            double futureNetWorth = 0;
            foreach(Asset a in Assets)
            {
                futureNetWorth += a.CurrentValue;
                if(a.HasInterest)
                    futureNetWorth += Math.Abs(a.CurrentValue) * ((a.InterestRate / 12.0) / 100.0) * months;
            }
            foreach(Liability l in Liabilities)
            {
                futureNetWorth -= l.CurrentValue;
                if(l.HasInterest)
                    futureNetWorth -= Math.Abs(l.CurrentValue) * ((l.InterestRate / 12.0) / 100.0) * months;
            }
            return futureNetWorth;
        }
    }
}