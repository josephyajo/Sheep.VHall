using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Modules
{
    public class WebinarList : BaseInfo
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public List<Lists> lists { get; set; }

        public int total { get; set; }
    }

    public class Lists
    {
        public Int64 webinar_id { get; set; }

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
