using System;

namespace Library.Exceptions
{
    public class FixingNotFoundException : Exception
    {
        public readonly string Fixing;
        public FixingNotFoundException(string fixing) : base($"Fixing for currency: {fixing} was not found.")
        {
            Fixing = fixing;
        }
    }
}
