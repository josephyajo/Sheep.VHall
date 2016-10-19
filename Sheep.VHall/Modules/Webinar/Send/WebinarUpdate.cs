using Sheep.Kernel.Net;
using Sheep.Kernel.Reflaction;
using Sheep.Kernel.Serialization;
using Sheep.Kernel.Validation.Attributes;
using Sheep.VHall.Message;
using Sheep.VHall.Modules.Webinar.Accept;
using System;
using System.Reflection;

namespace Sheep.VHall.Modules.Webinar.Send
{
    public class WebinarUpdate : BaseSend, ISender
    {
        /// <summary>
        /// 活动ID,9位数字 
        /// </summary>
        [Required]
        public int webinar_id { get; set; }

        /// <summary>
        /// 活动主题,<50个字符 
        /// </summary>
        [Required]
        public string subject { get; set; }

        /// <summary>
        /// 活动开始时间,Linux时间戳 
        /// </summary>
        [Required]
        public int start_time { get; set; }

        /// <summary>
        /// 默认为0不开启，1为开启,是否针对此活动开启全局K值配置 
        /// </summary>
        public int? use_global_k { get; set; }

        /// <summary>
        /// 是否开启第三方K值验证查看说明,默认为0不开启，1为开启 
        /// </summary>
        public int? exist_3rd_auth { get; set; }

        /// <summary>
        /// 权限校验路径
        /// </summary>
        public string auth_url { get; set; }

        /// <summary>
        /// 活动描述,<1024个字符 
        /// </summary>
        public string introduction { get; set; }

        /// <summary>
        /// 观看布局,1为单视频,2为单文档,3为文档+视频 
        /// </summary>
        public int? layout { get; set; }

        /// <summary>
        /// 活动公开状态,0为公开,1为非公开
        /// </summary>
        public int? is_open { get; set; }

        /// <summary>
        /// 是否自动回放,0为否,1为是
        /// </summary>
        public int? auto_record { get; set; }

        /// <summary>
        /// 是否开启聊天,0为是,1为否
        /// </summary>
        public int? is_chat { get; set; }

        /// <summary>
        /// 主持人姓名,<50个字符,可为空
        /// </summary>
        public string host { get; set; }

        /// <summary>
        /// 直播延时,>0的数字,可为空 
        /// </summary>
        public int? buffer { get; set; }

        dynamic ISender.Send(string request)
        {
            HttpContext interaction = new HttpContext(request);
            IStringSerializer factory = new JsonSerializerFactory().GetStringSerializer();
            return factory.Deserialize<WebinarUpdateAccept>(interaction.Get());
        }
    }
}
