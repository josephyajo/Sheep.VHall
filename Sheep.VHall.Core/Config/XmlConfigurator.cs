using System.Xml;
using Sheep.VHall.Core.Util;

namespace Sheep.VHall.Core.Config
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
