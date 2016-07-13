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
        WebinarList FetchWebinarList();

        WebinarState FetchWebinarState(string webinar_id);
    }
}
