using System;
using NetWorthApi.Models;
using NetWorthApi.Models.ValueObjects;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace NetWorthApi 
{
    public class Asset : NWFactor
    {
        enum AssetType {CheckingAccount = 0, SavingsAccount, Vehicle, Home}
        public Asset(string name, int type, NWFactorValue currVal, double intRate)
            : base(name, type, currVal, intRate)
        {
            this.VerifyInterestRate();
        }
        override protected void VerifyInterestRate()
        {
            //Just make sure the interest rate is > 0
        }

    }
}