using System;

namespace Sheep.VHall.Util
{
    internal class SecurityHandle
    {
        public static double ConvertUnixTimeStamp(DateTime time)
        {
            double intResult = 0;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }
    }
}
