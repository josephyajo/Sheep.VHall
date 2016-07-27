using System.Collections.Generic;

namespace Sheep.VHall.Core.Modules
{
    public class WebinarListResponse : BaseResponse
    {
        public WebinarListData data { get; set; }
    }

    public class WebinarListData
    {
        public List<Lists> lists { get; set; }

        public int total { get; set; }
    }

    public class Lists
    {
        public int webinar_id { get; set; }

        public string subject { get; set; }

        public string start_time { get; set; }

        public Status status { get; set; }

        public string desc { get; set; }

        public string thumb { get; set; }
    }

    public enum Status
    {
        直播进行中 = 1,
        预约中 = 2,
        结束 = 3,
        回放 = 4
    }
}
