using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Sheep.VHall.Core.Util
{
    internal class JsonHandle
    {
        public static T JsonToObject<T>(string jsonStr)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));
            T jsonObj;
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonStr)))
            {
                jsonObj = (T)json.ReadObject(ms);
            }
            if (jsonObj == null)
                return default(T);
            else
                return jsonObj;
        }
    }
}
