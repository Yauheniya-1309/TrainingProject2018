using System;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using My3Business;
using My3Common;
using System.Collections.Generic;
using My3Common.Controllers;
using System.Web.Mvc;
using My3.Controllers;

namespace My3.Test
{
    [TestClass]
    public class EventControllerTest
    {
        [TestMethod]
        public void TestEventDetailsById()
        {
            var mock = new Mock<IBusinessLayer>();
            mock.Setup(a => a.GetEvents()).Returns(new List<Event>());
            
            EventController controller = new EventController(mock.Object);

            // Act

            ViewResult result = controller.Details(-99) as ViewResult;

            // Assert
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void TestEventEditById()
        {
            var mock = new Mock<IBusinessLayer>();
            mock.Setup(a => a.GetEvents()).Returns(new List<Event>());

            EventController controller = new EventController(mock.Object);

            // Act

            ViewResult result = controller.Edit(2) as ViewResult;

            // Assert
            Assert.IsNull(result.Model);
        }


        [TestMethod]
        public void TestEventDeleteById()
        {
            var mock = new Mock<IBusinessLayer>();
            mock.Setup(a => a.GetEvents()).Returns(new List<Event>());

            EventController controller = new EventController(mock.Object);

            // Act

            ViewResult result = controller.Delete(-99) as ViewResult;

            // Assert
            Assert.IsNull(result.Model);
        }



    }
}
