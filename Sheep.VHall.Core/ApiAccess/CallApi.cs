using Sheep.VHall.Core.Util;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Core.ApiAccess
{
    public class CallApi
    {
        internal static T HttpPost<T>(string url, string postData)
        {
            byte[] data = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Proxy = null;
            using (Stream reqStream = request.GetRequestStreamAsync().Result)
            {
                reqStream.Write(data, 0, data.Length);
            }

            string receiveData = string.Empty;
            HttpWebResponse response = request.GetResponseAsync().Result as HttpWebResponse;
            using (Stream respStream = response.GetResponseStream())
            {
                using (StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8))
                {
                    receiveData = respStreamReader.ReadToEnd();
                }
            }

            string result = ConvertHandle.ToGB2312(receiveData);

            return JsonHandle.JsonToObject<T>(result);
        }
    }
}
