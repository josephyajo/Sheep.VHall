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

            IVHallHandler vhallHandler = new VHallHandler(AuthType.Verification);
            WebinarList val = vhallHandler.FetchWebinarList();
            Assert.IsNotNull(val);
        }

        [TestMethod()]
        public void GetWebinarStateTest()
        {
            IVHallHandler vhallHandler = new VHallHandler(AuthType.Verification);
            WebinarState val = vhallHandler.FetchWebinarState("833879698");
            Assert.IsNotNull(val);
        }
    }
}