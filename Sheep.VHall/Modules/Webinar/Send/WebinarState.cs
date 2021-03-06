﻿using Sheep.Kernel.Convertion;
using Sheep.Kernel.Net;
using Sheep.Kernel.Serialization;
using Sheep.Kernel.Validation.Attributes;
using Sheep.VHall.Handlers;
using Sheep.VHall.Message;
using Sheep.VHall.Modules.Webinar.Accept;

namespace Sheep.VHall.Modules.Webinar.Send
{
    public class WebinarState : BaseSend, ISender
    {
        /// <summary>
        /// 活动ID 9位数字
        /// </summary>
        [Required]
        public int webinar_id { get; set; }

        dynamic ISender.Send(string request)
        {
            HttpContext interaction = new HttpContext(request);
            string result = ConvertionHandler.ToGB2312(interaction.Post());
            IStringSerializer factory = new JsonSerializerFactory().GetStringSerializer();
            return factory.Deserialize<WebinarStateAccept>(DataFilterHandler.JsonFilter(result));
        }
    }
}
