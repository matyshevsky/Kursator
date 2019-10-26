namespace Domain.FixingDomain
{
    public static class FixingConverter 
    {
        public static decimal ConvertTo(this Fixing source, Fixing dest, decimal value)
        {
            return (value * source.Rate) / dest.Rate; 
        }
    }
}
