using Sheep.VHall.Config;
using Sheep.VHall.Modules;
using Sheep.VHall.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Sheep.VHall
{
    public enum AuthType
    {
        Verification = 1,
        Autograph = 2
    }

    public class VHallHandler : IVHallHandler
    {
        private int auth_type = 0;
        private static VHallConfig vhallConfig;
        private static string signed_at = string.Empty;
        private static string sign = string.Empty;

        private string initPostData = string.Empty;

        private const string api_url = "http://e.vhall.com/api/vhallapi/v2/";
        private const string webinar_list_url = api_url + "webinar/list";
        private const string webinar_state_url = api_url + "webinar/state";

        public bool IsReady { get; private set; }

        public VHallHandler(AuthType type)
        {
            if (vhallConfig == null)
            {
                vhallConfig = XmlConfigurator.Configure<VHallConfig>();
            }

            switch (type)
            {
                case AuthType.Verification:
                    {
                        auth_type = type.GetHashCode();
                        Verification verification = vhallConfig.Verification;
                        initPostData = "auth_type=" + auth_type.ToString() + "&account=" + verification.account + "&password=" + verification.password;

                        IsReady = true;
                    }
                    break;
                case AuthType.Autograph:
                    {
                        auth_type = type.GetHashCode();
                        Autograph autograph = vhallConfig.Autograph;
                        signed_at = SecurityHandle.ConvertUnixTimeStamp(DateTime.Now).ToString();
                        Dictionary<string, object> d = new Dictionary<string, object>();

                        IsReady = true;
                    }
                    break;
                default:
                    break;
            }
        }

        //获取活动列表
        public WebinarList FetchWebinarList()
        {
            if (IsReady)
                return HttpPost<WebinarList>(webinar_list_url, initPostData + "&type=1");
            else
                return null;
        }

        //获取活动信息
        public WebinarState FetchWebinarState(string webinar_id)
        {
            if (IsReady)
                return HttpPost<WebinarState>(webinar_state_url, initPostData + "&webinar_id=" + webinar_id);
            else
                return null;
        }

        private T HttpPost<T>(string url, string postData)
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
