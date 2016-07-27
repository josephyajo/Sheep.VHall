using System.Configuration;
using System.Xml;

namespace Sheep.VHall.Config
{
    internal class ConfigurationSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            return section;
        }
    }
}
