namespace Sheep.VHall.Core.Config
{
    [XmlRoot("vhall")]
    public class VHallBaseConfig
    {
        [XmlElement("path")]
        public string Path { get; set; }
    }
}
