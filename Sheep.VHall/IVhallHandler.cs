using Sheep.VHall.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall
{
    public interface IVHallHandler
    {
        bool IsReady { get; }

        WebinarList FetchWebinarList(int type = 1, int pos = 0, int limit = 0, int?[] status = null);

        WebinarState FetchWebinarState(int webinar_id);
    }
}
