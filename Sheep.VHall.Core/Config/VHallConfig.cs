using Sheep.VHall.Util;
using System;
using System.Xml.Serialization;

namespace Sheep.VHall.Core.Config
{
    public enum AuthType
    {
        Verification = 1,
        Autograph = 2
    }

    [XmlRoot("vhallconfig")]
    public class VHallConfig
    {
        [XmlElement("security")]
        public Security Security { get; set; }
    }

    public class Security
    {
        [XmlAttribute("auth_type")]
        public AuthType AuthType { get; set; }

        [XmlElement("verification")]
        public Verification Verification { get; set; }

        [XmlElement("autograph")]
        public Autograph Autograph { get; set; }

        public override string ToString()
        {
            string value = string.Empty;
            switch (AuthType)
            {
                case AuthType.Verification:
                    {
                        value = string.Format("auth_type={0}&account={1}&password={2}", AuthType.GetHashCode().ToString(), Verification.Account, Verification.Password);
                    }
                    break;
                case AuthType.Autograph:
                    {
                        Autograph.SignedAt = SecurityHandle.ConvertUnixTimeStamp(DateTime.Now).ToString();
                        value = string.Format("auth_type={0}&app_key={1}&secret_key={2}&signed_at={3}", AuthType.GetHashCode().ToString(), Autograph.AppKey, Autograph.SecretKey, Autograph.SignedAt);
                    }
                    break;
                default:
                    break;
            }
            return value;
        }
    }

    public class Verification
    {
        [XmlElement("account")]
        public string Account { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }
    }

    public class Autograph
    {
        [XmlElement("app_key")]
        public string AppKey { get; set; }

        [XmlElement("secret_key")]
        public string SecretKey { get; set; }

        [XmlIgnore]
        public string SignedAt { get; set; }
    }
}
