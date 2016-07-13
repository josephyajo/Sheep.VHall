using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sheep.VHall.Config
{
    public class Autograph
    {
        [XmlElement]
        public string app_key { get; set; }

        [XmlElement]
        public string secret_key { get; set; }

    }
}
