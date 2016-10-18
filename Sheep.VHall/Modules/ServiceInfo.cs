using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Modules
{
    internal class ServiceInfo
    {
        public const string GATEWAY = "http://e.vhall.com/api/vhallapi/v2/";
        /// <summary>
        /// 获取活动列表
        /// </summary>
        public const string WEBINAR_LIST = "webinar/list";
        /// <summary>
        /// 获取活动状态
        /// </summary>
        public const string WEBINAR_STATE = "webinar/state";
        /// <summary>
        /// 获取活动信息
        /// </summary>
        public const string WEBINAR_FETCH = "webinar/fetch";
        /// <summary>
        /// 更新活动信息
        /// </summary>
        public const string WEBINAR_UPDATE = "webinar/update";
    }
}
