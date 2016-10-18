using Sheep.Kernel.Net;
using Sheep.Kernel.Serialization;
using Sheep.VHall.Message;
using Sheep.VHall.Modules.Webinar.Accept;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Modules.Webinar.Send
{
    public class WebinarFetch : BaseSend, ISender
    {


        dynamic ISender.Send(string request)
        {
            HttpContext interaction = new HttpContext(request);
            IStringSerializer factory = new JsonSerializerFactory().GetStringSerializer();
            return factory.Deserialize<WebinarFetchAccept>(interaction.Get());
        }
    }
}
