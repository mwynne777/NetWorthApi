using BusinessLogic;
using BusinessLogic.Exceptions;
using NetWorthApi.Models.ValueObjects;
using System;

namespace NetWorthApi.Models
{
    public abstract class NWFactor
    {
        #region Protected Fields
        protected long id;
        protected string name;
        protected NWFactorValue currentValue;
        protected bool hasInterest;
        protected double interestRate;
        protected int type;
        #endregion

        #region Public Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public NWFactorValue CurrentValue { get; set; } //Obviously some value type
        public bool HasInterest { get; set; }
        public double InterestRate { get; set; } //Maybe a value type
        public int Type { get; set; }  //Maybe an Enum?
        #endregion

        #region Construction
        public NWFactor(string name, int type, NWFactorValue currVal, double intRate)
        {
            this.Name = name;
            this.Type = type;
            this.CurrentValue = currVal;
            this.InterestRate = intRate;

            if(intRate != 0)
                this.HasInterest = true;
        }
        #endregion

        #region Public Methods
        public NWFactorValue CalculateValueByDate(DateTime futureDate)
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
        }
        #endregion

        #region Abstract Methods
        protected abstract void VerifyInterestRate();
        #endregion
    }
}