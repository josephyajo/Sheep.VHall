using Sheep.VHall.Modules.Config;
using System;
using System.IO;
using System.Text;

namespace Sheep.VHall.Handlers
{
    public class GenerateHandler
    {
        public static VHallConfig Config;

        static GenerateHandler()
        {
            Config = new VHallConfig().GetConfig();
        }

        public static double GenerateUnixTimeStamp(DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (time - startTime).TotalSeconds;
        }
    }
}
