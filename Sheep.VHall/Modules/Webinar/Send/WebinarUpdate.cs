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
        [Required]
        public int webinar_id { get; set; }

        [Required]
        public string subject { get; set; }

        [Required]
        public int start_time { get; set; }

        public int? use_global_k { get; set; }

        public int? exist_3rd_auth { get; set; }

        public string auth_url { get; set; }

        public string introduction { get; set; }

        public int? layout { get; set; }

        public int? is_open { get; set; }

        public int? auto_record { get; set; }

        public int? is_chat { get; set; }

        public string host { get; set; }

        public int? buffer { get; set; }

        dynamic ISender.Send(string request)
        {
            HttpContext interaction = new HttpContext(request);
            IStringSerializer factory = new JsonSerializerFactory().GetStringSerializer();
            return factory.Deserialize<WebinarUpdateAccept>(interaction.Get());
        }
    }
}
