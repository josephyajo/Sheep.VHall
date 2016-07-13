using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sheep.VHall.Config
{
    public class Verification
    {
        [XmlElement]
        public string account { get; set; }

        [XmlElement]
        public string password { get; set; }

    }
}
