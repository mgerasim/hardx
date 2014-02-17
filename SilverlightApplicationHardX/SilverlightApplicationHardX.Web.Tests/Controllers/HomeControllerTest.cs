using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilverlightApplicationHardX.Web;
using SilverlightApplicationHardX.Web.Controllers;

namespace SilverlightApplicationHardX.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Упорядочение
            HomeController controller = new HomeController();

            // Действие
            ViewResult result = controller.Index() as ViewResult;

            // Утверждение
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Добро пожаловать в ASP.NET MVC!", viewData["Message"]);
        }

        [TestMethod]
        public void About()
        {
            // Упорядочение
            HomeController controller = new HomeController();

            // Действие
            ViewResult result = controller.About() as ViewResult;

            // Утверждение
            Assert.IsNotNull(result);
        }
    }
}
