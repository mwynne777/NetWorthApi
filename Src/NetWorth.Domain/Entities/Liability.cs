using System;
using NetWorth.Domain.Entities;
using NetWorth.Domain.ValueObjects;
using NetWorth.Domain.Exceptions;

namespace NetWorth.Domain.Entities 
{
    public class Liability : NWFactor
    {
        enum LiabilityType {Debt = 0, Loan, Mortgage}
        
        /*override protected void VerifyInterestRate()
        {
            //Just make sure the interest rate is < 0
        }*/

    }
}