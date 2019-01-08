using NetWorth.Domain.Exceptions;
using NetWorth.Domain.ValueObjects;
using System;

namespace NetWorth.Domain.Entities
{
    public abstract class NWFactor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double CurrentValue { get; set; } //Obviously some value type
        public bool HasInterest { get; set; }
        public double InterestRate { get; set; } //Maybe a value type
        public int Type { get; set; }  //Maybe an Enum?
        public long UserID { get; set; }


        public User User { get; set; }

        /*public NWFactor(string name, int type, NWFactorValue currVal, double intRate)
        {
            this.Name = name;
            this.Type = type;
            this.CurrentValue = currVal;
            this.InterestRate = intRate;

            if(intRate != 0)
                this.HasInterest = true;
        }*/

        /*public NWFactorValue CalculateValueByDate(DateTime futureDate)
        {
            //Simple implementation
            if(this.HasInterest)
            {
                //Assume annual rate for now with no more precision than monthly
                try
                {
                    DateTime today = new DateTime();
                    int months = DateCalculations.GetMonthsBetweenTwoDates(today, futureDate);
                    return new NWFactorValue((this.CurrentValue.Value * this.InterestRate * months));
                }
                catch(InvalidDateSubtractionException ex)
                {
                    throw;
                }
            }
            else
                return this.CurrentValue;
        }*/

        //protected abstract void VerifyInterestRate();
    }
}