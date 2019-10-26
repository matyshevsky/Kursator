using Domain.FixingDomain;
using Library.Exceptions;
using System.Collections.Generic;

namespace Library.Extensions
{
    public static class FixingDictionaryExtensions
    {
        public static Fixing Get(this IDictionary<string, Fixing> source, string key)
        {
            try
            {
                return source[key];
            }
            catch (KeyNotFoundException)
            {
                throw new FixingNotFoundException(key);
            }
        }
    }

}
