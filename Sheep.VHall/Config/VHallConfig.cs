using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sheep.VHall.Config
{
    [XmlRoot("vhallconfig")]
    public class VHallConfig
    {
        [XmlElement("autograph")]
        public Autograph Autograph { get; set; }

        [XmlElement("verification")]
        public Verification Verification { get; set; }
    }
}
