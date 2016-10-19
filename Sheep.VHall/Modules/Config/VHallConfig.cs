using Sheep.Kernel.Configuration;
using Sheep.VHall.Handlers;
using System;
using System.Xml.Serialization;

namespace Sheep.VHall.Modules.Config
{
    [XmlRoot("vhallconfig")]
    public class VHallConfig
    {
        [XmlElement("auth_type")]
        public int AuthType { get; set; }

        [XmlElement("app_key")]
        public string AppKey { get; set; }

        [XmlElement("secret_key")]
        public string SecretKey { get; set; }

        public VHallConfig GetConfig()
        {
            ConfiguratorManager manager = new ConfiguratorManager();
            XmlConfigurator configurator = new XmlConfigurator(manager);
            Kernel.Configuration.XmlSerializer serializer = new Kernel.Configuration.XmlSerializer(manager);
            return manager.Get<VHallConfig>(configurator);
        }
    }
}
