using Sheep.VHall.Util;
using System.IO;
using System.Net;
using System.Text;

namespace Sheep.VHall.ApiAccess
{
    public class CallApi
    {
        internal static T HttpPost<T>(string url, string postData)
        {
            byte[] data = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Proxy = null;
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string receiveData = string.Empty;
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
