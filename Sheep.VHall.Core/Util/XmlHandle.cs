using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Sheep.VHall.Core.Util
{
    internal class XmlHandle
    {
        internal static void XmlSerializable<T>(T value, string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");
            if (value == null)
                throw new ArgumentNullException("value");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            using (stream)
            {
                xmlSerializer.Serialize(stream, value);
            }
        }

        internal static T XmlDeserialize<T>(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(value)))
            {
                using (StreamReader reader = new StreamReader(ms, true))
                {
                    return (T)xmlSerializer.Deserialize(reader);
                }
            }
        }

        internal static T XmlDeserializeFromFile<T>(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            string xml = File.ReadAllText(path);

            return XmlDeserialize<T>(xml);
        }

        internal static Hashtable ParseXmlObject(XmlNode section, Hashtable table)
        {
            foreach (XmlAttribute attrib in section.Attributes)
            {
                if (XmlNodeType.Attribute == attrib.NodeType)
                {
                    table.Add(attrib.Name, attrib.Value);
                }
            }

            foreach (XmlNode child in section.ChildNodes)
            {
                if (XmlNodeType.Element == child.NodeType)
                {
                    if (child.HasChildNodes)
                    {
                        ParseXmlObject(child, table);
                    }
                    else
                    {
                        table.Add(child.Name, child.Value);
                    }
                }
            }

            return table;
        }

    }
}
