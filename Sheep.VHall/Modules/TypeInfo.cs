using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Modules
{
    /// <summary>
    /// 权限类型
    /// </summary>
    public enum AuthType
    {
        Verification = 1,
        Autograph = 2
    }

    /// <summary>
    /// 直播状态
    /// </summary>
    public enum Status
    {
        直播进行中 = 1,
        预约中 = 2,
        结束 = 3,
        回放 = 4
    }
}
