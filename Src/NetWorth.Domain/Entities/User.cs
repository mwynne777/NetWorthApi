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

        public Dictionary<DateTime,double> GetFutureNetWorthByMonth(DateTime currentDate, DateTime futureDate)
        {
            Dictionary<DateTime,double> netWorthDict = new Dictionary<DateTime,double>();
            List<DateTime> dates = DateCalculations.GetAllMonthsBetweenTwoDates(currentDate, futureDate);

            Asset[] assetsClone = new Asset[Assets.Count];
            Assets.CopyTo(assetsClone, 0);
            Liability[] liabilitiesClone = new Liability[Liabilities.Count];
            Liabilities.CopyTo(liabilitiesClone, 0);

            for(int i = 0; i < dates.Count; i++)
            {
                double futureNetWorth = 0;
                foreach(Asset a in assetsClone)
                {
                    futureNetWorth += (a.CurrentValue += Math.Abs(a.CurrentValue) * ((a.InterestRate / 12.0) / 100.0));
                }

                foreach(Liability l in liabilitiesClone)
                {
                    futureNetWorth -= (l.CurrentValue += Math.Abs(l.CurrentValue) * ((l.InterestRate / 12.0) / 100.0));
                }
                netWorthDict.Add(dates[i], futureNetWorth);
            }

            return netWorthDict;
        }
    }
}