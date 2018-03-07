using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VolunteerSystem;
using VolunteerSystem.Controllers;
using VolunteerSystem.DAL;
using VolunteerSystem.Models;

namespace VolunteerSystem.Tests.Controllers
{
    [TestClass]
    public class JobControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            JobController controller = new JobController();
     

            // Assert
            Assert.AreEqual("Your Job Page", controller.ViewBag.Message);

        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            JobController controller = new JobController();

            // Act
            ViewResult result = controller.Details(1045) as ViewResult;
            // Assert
            Assert.AreEqual("Your Job Detail Page", controller.ViewBag.Message);

        }

    }
}
