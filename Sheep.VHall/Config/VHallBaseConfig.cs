using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
