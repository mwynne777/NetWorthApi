namespace NetWorth.Domain.Entities
{
    public class Contribution
    {

        //TODO: Add frequency variability; default to monthly for now
        public long Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public long FactorID { get; set; }
        //public NWFactor Factor { get; set; }

    }
}