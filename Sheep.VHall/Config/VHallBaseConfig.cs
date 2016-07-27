using System.Xml.Serialization;

namespace Sheep.VHall.Config
{
    [XmlRoot("vhall")]
    public class VHallBaseConfig
    {
        [XmlElement("path")]
        public string Path { get; set; }
    }
}
