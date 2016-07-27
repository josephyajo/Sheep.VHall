using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheep.VHall;
using Sheep.VHall.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Tests
{
    [TestClass()]
    public class VHallHandlerTests
    {
        [TestMethod()]
        public void GetWebinarListTest()
        {
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarListResponse val = vhallHandler.FetchWebinarList();
            Assert.IsNotNull(val);
        }

        [TestMethod()]
        public void FetchWebinarStateTest()
        {
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarStateResponse val = vhallHandler.FetchWebinarState(833879698);
            Assert.IsNotNull(val);
        }

        [TestMethod()]
        public void GetWebinarFetchTest()
        {
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarFetchResponse val = vhallHandler.GetWebinarFetch(833879698);
            Assert.IsNotNull(val);
        }

        [TestMethod()]
        public void SendWebinarUpdateTest()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarUpdateResponse val = vhallHandler.SendWebinarUpdate(new WebinarUpdateRequest { webinar_id = 791652516, subject = "Test1", start_time = (int)(DateTime.Parse("2016-07-29 23:31:00") - startTime).TotalSeconds, exist_3rd_auth = 1, auth_url = "http://www.3wdian.cn/manage/account/" });
            Assert.IsNotNull(val);
        }
    }
}