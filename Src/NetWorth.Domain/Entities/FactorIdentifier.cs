using System;
using NetWorth.Domain.Entities;

namespace NetWorth.Domain.Entities 
{
    public class FactorIdentifier
    {
        public enum FactorType { Asset = 0, Liability = 1 };
        public long Id { get; set; }
        public int Type { get; set; }
    }
}