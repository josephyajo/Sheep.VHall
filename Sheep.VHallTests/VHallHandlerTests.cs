using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheep.VHall.Modules;
using Sheep.VHall.Modules.Webinar.Send;
using System;

namespace Sheep.VHall.Tests
{
    [TestClass()]
    public class VHallHandlerTests
    {
        [TestMethod()]
        public void GetWebinarListTest()
        {
            WebinarList webinarList = new WebinarList
            {
                limit = 10,
                pos = 1,
                type = 1
            };
            dynamic result = VHallClient<Webinar>.Handle(webinarList);
        }

        [TestMethod()]
        public void FetchWebinarStateTest()
        {
            WebinarState webinarState = new WebinarState
            {
                webinar_id = 180256660
            };
            dynamic obj = VHallClient<Webinar>.Handle(webinarState);
        }

        [TestMethod()]
        public void GetWebinarFetchTest()
        {
            WebinarFetch webinarFetch = new WebinarFetch
            {
                webinar_id = 180256660,
                fields = "id,subject"
            };
            dynamic obj = VHallClient<Webinar>.Handle(webinarFetch);
        }

        [TestMethod()]
        public void SendWebinarUpdateTest()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            WebinarUpdate webinarFetch = new WebinarUpdate
            {
                webinar_id = 615369354,
                subject = "实盘ETC",
                start_time = (int)(DateTime.Parse("2016-08-16 17:04:00") - startTime).TotalSeconds,
                exist_3rd_auth = 1,
                auth_url = "http://www.3wdian.cn/api/MobileVideo/"
            };
            dynamic obj = VHallClient<Webinar>.Handle(webinarFetch);
        }
    }
}