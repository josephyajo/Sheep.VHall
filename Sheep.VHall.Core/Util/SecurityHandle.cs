using System;

namespace Sheep.VHall.Core.Util
{
    internal class SecurityHandle
    {
        public static double ConvertUnixTimeStamp(DateTime time)
        {
            double intResult = 0;
            DateTime startTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }
    }
}
