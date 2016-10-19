using Sheep.VHall.Message;
using Sheep.Kernel.Net;
using Sheep.Kernel.Serialization;
using Sheep.VHall.Modules.Webinar.Accept;
using Sheep.Kernel.Convertion;
using Sheep.VHall.Handlers;

namespace Sheep.VHall.Modules.Webinar.Send
{
    public class WebinarList : BaseSend, ISender
    {
        /// <summary>
        /// 0为网站公开活动，1为个人所有活动,0/1 
        /// </summary>
        public int? type { get; set; }

        /// <summary>
        /// 数字,设置从第几条数据开始获取，如果是第一条数据（pos=0） 
        /// </summary>
        public int? pos { get; set; }

        /// <summary>
        /// 数字,每次返回条数 
        /// </summary>
        public int? limit { get; set; }

        /// <summary>
        /// 1:直播进行中,2:预约中,3:结束 为空则为所有活动,（如需组合查询,可将该值写成json字符串的形式。如status为[1,2]代表同时获取活动状态,活动状态 
        /// </summary>
        public int?[] status { get; set; }

        dynamic ISender.Send(string request)
        {
            HttpContext interaction = new HttpContext(request);
            string result = ConvertionHandler.ToGB2312(interaction.Post());
            IStringSerializer factory = new JsonSerializerFactory().GetStringSerializer();
            return factory.Deserialize<WebinarListAccept>(DataFilterHandler.JsonFilter(result));
        }
    }
}
