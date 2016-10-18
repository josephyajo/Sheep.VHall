using Sheep.VHall.Handlers;
using Sheep.VHall.Modules.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Modules.Webinar.Send
{
    public class BaseSend
    {
        /// <summary>
        /// 授权类型
        /// </summary>
        public int auth_type { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string app_key { get; set; }

        /// <summary>
        /// Unix时间戳
        /// </summary>
        public string signed_at { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        public BaseSend()
        {
            VHallConfig config = GenerateHandler.Config;
            auth_type = config.AuthType;
            app_key = config.AppKey;
            signed_at = GenerateHandler.GenerateUnixTimeStamp(DateTime.Now).ToString();
        }
    }
}
