namespace NetWorth.Domain.ValueObjects
{
    public class NWFactorValue
    {
        public double Value { get; set; }

        public NWFactorValue(double val)
        {
            //Some Error Checking
            this.Value = val;
        }
    }
}