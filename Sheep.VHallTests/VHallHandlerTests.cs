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
                pos = 0,
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
                webinar_id = 792300546,
                subject = "三连阳金融终端特供版",
                start_time = (int)(DateTime.Parse("2016-11-17 17:04:00") - startTime).TotalSeconds,
                exist_3rd_auth = 1,
                auth_url = "http://tg.sanlianyang.com/video/live/kvalue/verify"
            };
            dynamic obj = VHallClient<Webinar>.Handle(webinarFetch);
        }
    }
}