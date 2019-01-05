using System;
using NetWorth.Domain.Models;
using NetWorth.Domain.ValueObjects;
using NetWorth.Domain.Exceptions;

namespace NetWorth.Domain.Models 
{
    public class Liability : NWFactor
    {
        enum LiabilityType {Debt = 0, Loan, Mortgage}
        public Liability(string name, int type, NWFactorValue currVal, double intRate)
            //: base(name, type, currVal, intRate)
        {
            //this.VerifyInterestRate();
        }
        /*override protected void VerifyInterestRate()
        {
            //Just make sure the interest rate is < 0
        }*/

    }
}