using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheep.VHall.Modules;
using System;

namespace Sheep.VHall.Tests
{
    [TestClass()]
    public class VHallHandlerTests
    {
        [TestMethod()]
        public void GetWebinarListTest()
        {
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarListAccept val = vhallHandler.FetchWebinarList();
            Assert.IsNotNull(val);
        }

        [TestMethod()]
        public void FetchWebinarStateTest()
        {
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarStateAccept val = vhallHandler.FetchWebinarState(833879698);
            Assert.IsNotNull(val);
        }

        [TestMethod()]
        public void GetWebinarFetchTest()
        {
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarFetchResponse val = vhallHandler.GetWebinarFetch(615369354);
            Assert.IsNotNull(val);
        }

        [TestMethod()]
        public void SendWebinarUpdateTest()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarUpdateAccept val = vhallHandler.SendWebinarUpdate(new WebinarUpdate { webinar_id = 615369354, subject = "实盘ETC", start_time = (int)(DateTime.Parse("2016-08-16 17:04:00") - startTime).TotalSeconds, exist_3rd_auth = 1, auth_url = "http://www.3wdian.cn/api/MobileVideo/" });
            Assert.IsNotNull(val);
        }
    }
}