using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Sheep.VHall.Core.Util;

namespace Sheep.VHall.Core.Config
{
    internal class XmlConfigurator
    {
        internal static T Configure<T>() where T : class
        {
            var builder = new ConfigurationBuilder();
            string vhallPath = Path.Combine(AppContext.BaseDirectory, "config.ini");
            builder.AddIniFile(vhallPath);

            var live = builder.Build().GetValue<VHallBaseConfig>("vhall");
            string path = Path.Combine(AppContext.BaseDirectory, live.Path, typeof(T).Name, ".xml");

            return XmlHandle.XmlDeserializeFromFile<T>(path);
        }

    }
}
