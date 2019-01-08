using System;
using NetWorth.Domain.Entities;
using NetWorth.Domain.ValueObjects;
using NetWorth.Domain.Exceptions;

namespace NetWorth.Domain.Entities 
{
    public class Asset : NWFactor
    {
        enum AssetType {CheckingAccount = 0, SavingsAccount, Vehicle, Home}
        
        /*override protected void VerifyInterestRate()
        {
            //Just make sure the interest rate is > 0
        }*/

    }
}