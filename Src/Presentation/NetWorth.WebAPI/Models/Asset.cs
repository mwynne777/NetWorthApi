using System;
using NetWorth.WebAPI.Models;
using NetWorth.WebAPI.Models.ValueObjects;
using NetWorth.WebAPI.BusinessLogic;
using NetWorth.WebAPI.BusinessLogic.Exceptions;

namespace NetWorth.WebAPI.Models 
{
    public class Asset : NWFactor
    {
        enum AssetType {CheckingAccount = 0, SavingsAccount, Vehicle, Home}
        public Asset(string name, int type, NWFactorValue currVal, double intRate)
            //: base(name, type, currVal, intRate)
        {
            //this.VerifyInterestRate();
        }
        /*override protected void VerifyInterestRate()
        {
            //Just make sure the interest rate is > 0
        }*/

    }
}