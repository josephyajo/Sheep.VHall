using Sheep.VHall.ApiAccess;
using Sheep.VHall.Config;
using Sheep.VHall.Modules;
using System;
using System.Text;

namespace Sheep.VHall
{
    public class VHallHandler : IVHallHandler
    {
        private static VHallConfig vhallConfig;
        private static string sign = string.Empty;

        private string initParameter = string.Empty;

        private const string api_url = "http://e.vhall.com/api/vhallapi/v2/";
        private const string webinar_list_url = api_url + "webinar/list";
        private const string webinar_state_url = api_url + "webinar/state";

        public bool IsReady { get; private set; }

        public VHallHandler()
        {
            if (vhallConfig == null)
            {
                vhallConfig = XmlConfigurator.Configure<VHallConfig>();
            }

            Security security = vhallConfig.Security;
            AuthType auth = security.AuthType;

            switch (auth)
            {
                case AuthType.Verification:
                    {
                        initParameter = security.ToString();
                    }
                    break;
                case AuthType.Autograph:
                    {
                        initParameter = security.ToString();
                    }
                    break;
                default:
                    break;
            }

            IsReady = true;
        }

        //获取活动列表
        public WebinarList FetchWebinarList(int type = 1, int pos = 0, int limit = 0, int?[] status = null)
        {
            if (IsReady)
            {
                StringBuilder parameter = new StringBuilder();
                parameter.AppendFormat("{0}&type={1}&pos={2}", initParameter, type, pos);
                if (limit != 0)
                    parameter.AppendFormat("&limit={0}", limit);
                if (status != null)
                    parameter.AppendFormat("&status=[{0}]", string.Join(",", status));
                return CallApi.HttpPost<WebinarList>(webinar_list_url, parameter.ToString());
            }
            else
                return null;
        }

        //获取活动信息
        public WebinarState FetchWebinarState(int webinar_id)
        {
            if (IsReady)
            {
                string parameter = string.Format("{0}&webinar_id={1}", initParameter, webinar_id);
                return CallApi.HttpPost<WebinarState>(webinar_state_url, parameter);
            }
            else
                return null;
        }

    }
}
