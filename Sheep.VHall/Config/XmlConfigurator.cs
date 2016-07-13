using Sheep.VHall.Util;
using System;
using System.Configuration;
using System.Xml;

namespace Sheep.VHall.Config
{
    internal class XmlConfigurator
    {
        internal static T Configure<T>() where T : class
        {
            XmlElement config = ConfigurationManager.GetSection("vhall") as XmlElement;

            VHallBaseConfig live = XmlHandle.XmlDeserialize<VHallBaseConfig>(config.OuterXml);

            string path = AppDomain.CurrentDomain.BaseDirectory + live.Path + typeof(T).Name + ".xml";

            return XmlHandle.XmlDeserializeFromFile<T>(path);
        }

    }
}
