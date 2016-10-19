using Sheep.Kernel.Convertion;
using Sheep.Kernel.Net;
using Sheep.Kernel.Serialization;
using Sheep.VHall.Handlers;
using Sheep.VHall.Message;
using Sheep.VHall.Modules.Webinar.Accept;

namespace Sheep.VHall.Modules.Webinar.Send
{
    public class WebinarFetch : BaseSend, ISender
    {
        /// <summary>
        /// 9位数字, 活动ID
        /// </summary>
        public string webinar_id { get; set; }

        /// <summary>
        /// 活动基础信息数据,字段之间用英文逗号,分割
        /// id                  活动ID  
        /// alias_name          别名，唯一，程序判断是否重复
        /// user_id             用户ID
        /// subject             活动标题
        /// introduction        活动简介
        /// img_url             封面图片
        /// category            类别
        /// is_open             是否公开,默认0为公开，1为不公开
        /// layout              布局，三分屏等，1为单视频，2为“语音+文档”，3为“视频+文档”  
        /// verify              验证类别，0 无验证，1 密码，2 白名单，3 付费活动, 4 F码, 5 报名表单
        /// password            活动密码设置
        /// type                1为直播，2为预约,3为结束,4为录播
        /// is_single_video     是否单视频，1为是
        /// is_iframe           是否允许切入,1为允许切入
        /// auto_record         是否自动回放，1为是，2为否
        /// is_chat             是否允许聊天，默认0为允许，1为不允许
        /// buffer              观看方延迟
        /// t_start             开始时间
        /// end_time            活动结束时间默认为0，代表永久，可以手动设置结束时间或彻底结束
        /// host                拥有者昵称
        /// live_start_time     最后一次开始直播时间
        /// </summary>
        public string fields { get; set; }

        dynamic ISender.Send(string request)
        {
            HttpContext interaction = new HttpContext(request);
            string result = ConvertionHandler.ToGB2312(interaction.Post());
            IStringSerializer factory = new JsonSerializerFactory().GetStringSerializer();
            return factory.Deserialize<WebinarFetchAccept>(DataFilterHandler.JsonFilter(result));
        }
    }
}
