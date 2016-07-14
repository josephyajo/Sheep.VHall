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
        private const string webinar_fetch_url = api_url + "webinar/fetch";
        private const string webinar_update_url = api_url + "webinar/update";

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
        public WebinarListResponse FetchWebinarList(FetchWebinarRequest request = null)
        {
            if (IsReady)
            {
                string parameter = string.Format("{0}{1}", initParameter, request == null ? new FetchWebinarRequest().ToString() : request.ToString());
                return CallApi.HttpPost<WebinarListResponse>(webinar_list_url, parameter.ToString());
            }
            else
                return null;
        }

        //获取活动信息
        public WebinarStateResponse FetchWebinarState(int webinar_id)
        {
            if (IsReady)
            {
                string parameter = string.Format("{0}&webinar_id={1}", initParameter, webinar_id);
                return CallApi.HttpPost<WebinarStateResponse>(webinar_state_url, parameter);
            }
            else
                return null;
        }

        public WebinarFetchResponse GetWebinarFetch(int webinar_id, string fields = null)
        {
            if (IsReady)
            {
                string parameter = string.Format("{0}&webinar_id={1}&fields={2}", initParameter, webinar_id, string.IsNullOrEmpty(fields) ? new WebinarFetchData().ToString() : fields);
                return CallApi.HttpPost<WebinarFetchResponse>(webinar_fetch_url, parameter);
            }
            else
                return null;
        }

        public WebinarUpdateResponse SendWebinarUpdate(WebinarUpdateRequest request = null)
        {
            if (IsReady)
            {
                string parameter = string.Format("{0}{1}", initParameter, request == null ? new WebinarFetchData().ToString() : request.ToString());
                return CallApi.HttpPost<WebinarUpdateResponse>(webinar_update_url, parameter);
            }
            else
                return null;
        }
    }
}
