using System;
using NetWorth.WebAPI.Models;
using NetWorth.WebAPI.Models.ValueObjects;
using NetWorth.WebAPI.BusinessLogic;
using NetWorth.WebAPI.BusinessLogic.Exceptions;

namespace NetWorth.WebAPI.Models 
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