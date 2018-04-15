using System;
using System.Numerics;

namespace M33.Services
{
    public class Utils
    {
        public static BigInteger getNowInUnixTimestamp()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var dt = (BigInteger)t.TotalMilliseconds;
            return dt;
        }
    }

}