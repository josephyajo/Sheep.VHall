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
            IVHallHandler vhallHandler = new VHallHandler();
            WebinarUpdateResponse val = vhallHandler.SendWebinarUpdate();
            Assert.IsNotNull(val);
        }
    }
}