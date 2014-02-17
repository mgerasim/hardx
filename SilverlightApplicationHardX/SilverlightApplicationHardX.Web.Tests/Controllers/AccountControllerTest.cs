using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilverlightApplicationHardX.Web;
using SilverlightApplicationHardX.Web.Controllers;
using SilverlightApplicationHardX.Web.Models;

namespace SilverlightApplicationHardX.Web.Tests.Controllers
{

    [TestClass]
    public class AccountControllerTest
    {

        [TestMethod]
        public void ChangePassword_Get_ReturnsView()
        {
            // Упорядочение
            AccountController controller = GetAccountController();

            // Действие
            ActionResult result = controller.ChangePassword();

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void ChangePassword_Post_ReturnsRedirectOnSuccess()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            ChangePasswordModel model = new ChangePasswordModel()
            {
                OldPassword = "goodOldPassword",
                NewPassword = "goodNewPassword",
                ConfirmPassword = "goodNewPassword"
            };

            // Действие
            ActionResult result = controller.ChangePassword(model);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("ChangePasswordSuccess", redirectResult.RouteValues["action"]);
        }

        [TestMethod]
        public void ChangePassword_Post_ReturnsViewIfChangePasswordFails()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            ChangePasswordModel model = new ChangePasswordModel()
            {
                OldPassword = "goodOldPassword",
                NewPassword = "badNewPassword",
                ConfirmPassword = "badNewPassword"
            };

            // Действие
            ActionResult result = controller.ChangePassword(model);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual("Неправильный текущий пароль или недопустимый новый пароль.", controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void ChangePassword_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            ChangePasswordModel model = new ChangePasswordModel()
            {
                OldPassword = "goodOldPassword",
                NewPassword = "goodNewPassword",
                ConfirmPassword = "goodNewPassword"
            };
            controller.ModelState.AddModelError("", "Заглушка сообщения об ошибке.");

            // Действие
            ActionResult result = controller.ChangePassword(model);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void ChangePasswordSuccess_ReturnsView()
        {
            // Упорядочение
            AccountController controller = GetAccountController();

            // Действие
            ActionResult result = controller.ChangePasswordSuccess();

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void LogOff_LogsOutAndRedirects()
        {
            // Упорядочение
            AccountController controller = GetAccountController();

            // Действие
            ActionResult result = controller.LogOff();

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignOut_WasCalled);
        }

        [TestMethod]
        public void LogOn_Get_ReturnsView()
        {
            // Упорядочение
            AccountController controller = GetAccountController();

            // Действие
            ActionResult result = controller.LogOn();

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void LogOn_Post_ReturnsRedirectOnSuccess_WithoutReturnUrl()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "goodPassword",
                RememberMe = false
            };

            // Действие
            ActionResult result = controller.LogOn(model, null);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [TestMethod]
        public void LogOn_Post_ReturnsRedirectOnSuccess_WithReturnUrl()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "goodPassword",
                RememberMe = false
            };

            // Действие
            ActionResult result = controller.LogOn(model, "/someUrl");

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            RedirectResult redirectResult = (RedirectResult)result;
            Assert.AreEqual("/someUrl", redirectResult.Url);
            Assert.IsTrue(((MockFormsAuthenticationService)controller.FormsService).SignIn_WasCalled);
        }

        [TestMethod]
        public void LogOn_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "goodPassword",
                RememberMe = false
            };
            controller.ModelState.AddModelError("", "Заглушка сообщения об ошибке.");

            // Действие
            ActionResult result = controller.LogOn(model, null);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
        }

        [TestMethod]
        public void LogOn_Post_ReturnsViewIfValidateUserFails()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            LogOnModel model = new LogOnModel()
            {
                UserName = "someUser",
                Password = "badPassword",
                RememberMe = false
            };

            // Действие
            ActionResult result = controller.LogOn(model, null);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual("Имя пользователя или пароль указаны неверно.", controller.ModelState[""].Errors[0].ErrorMessage);
        }

        [TestMethod]
        public void Register_Get_ReturnsView()
        {
            // Упорядочение
            AccountController controller = GetAccountController();

            // Действие
            ActionResult result = controller.Register();

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(10, ((ViewResult)result).ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void Register_Post_ReturnsRedirectOnSuccess()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            RegisterModel model = new RegisterModel()
            {
                UserName = "someUser",
                Email = "goodEmail",
                Password = "goodPassword",
                ConfirmPassword = "goodPassword"
            };

            // Действие
            ActionResult result = controller.Register(model);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)result;
            Assert.AreEqual("Home", redirectResult.RouteValues["controller"]);
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
        }

        [TestMethod]
        public void Register_Post_ReturnsViewIfRegistrationFails()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            RegisterModel model = new RegisterModel()
            {
                UserName = "duplicateUser",
                Email = "goodEmail",
                Password = "goodPassword",
                ConfirmPassword = "goodPassword"
            };

            // Действие
            ActionResult result = controller.Register(model);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual("Имя пользователя уже существует. Введите другое имя пользователя.", controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        [TestMethod]
        public void Register_Post_ReturnsViewIfModelStateIsInvalid()
        {
            // Упорядочение
            AccountController controller = GetAccountController();
            RegisterModel model = new RegisterModel()
            {
                UserName = "someUser",
                Email = "goodEmail",
                Password = "goodPassword",
                ConfirmPassword = "goodPassword"
            };
            controller.ModelState.AddModelError("", "Заглушка сообщения об ошибке.");

            // Действие
            ActionResult result = controller.Register(model);

            // Утверждение
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(model, viewResult.ViewData.Model);
            Assert.AreEqual(10, viewResult.ViewData["PasswordLength"]);
        }

        private static AccountController GetAccountController()
        {
            AccountController controller = new AccountController()
            {
                FormsService = new MockFormsAuthenticationService(),
                MembershipService = new MockMembershipService()
            };
            controller.ControllerContext = new ControllerContext()
            {
                Controller = controller,
                RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
            };
            return controller;
        }

        private class MockFormsAuthenticationService : IFormsAuthenticationService
        {
            public bool SignIn_WasCalled;
            public bool SignOut_WasCalled;

            public void SignIn(string userName, bool createPersistentCookie)
            {
                // убедитесь, что аргументы именно такие, которые требуются
                Assert.AreEqual("someUser", userName);
                Assert.IsFalse(createPersistentCookie);

                SignIn_WasCalled = true;
            }

            public void SignOut()
            {
                SignOut_WasCalled = true;
            }
        }

        private class MockHttpContext : HttpContextBase
        {
            private readonly IPrincipal _user = new GenericPrincipal(new GenericIdentity("someUser"), null /* roles */);

            public override IPrincipal User
            {
                get
                {
                    return _user;
                }
                set
                {
                    base.User = value;
                }
            }
        }

        private class MockMembershipService : IMembershipService
        {
            public int MinPasswordLength
            {
                get { return 10; }
            }

            public bool ValidateUser(string userName, string password)
            {
                return (userName == "someUser" && password == "goodPassword");
            }

            public MembershipCreateStatus CreateUser(string userName, string password, string email)
            {
                if (userName == "duplicateUser")
                {
                    return MembershipCreateStatus.DuplicateUserName;
                }

                // убедитесь, что значения именно такие, которые требуются
                Assert.AreEqual("goodPassword", password);
                Assert.AreEqual("goodEmail", email);

                return MembershipCreateStatus.Success;
            }

            public bool ChangePassword(string userName, string oldPassword, string newPassword)
            {
                return (userName == "someUser" && oldPassword == "goodOldPassword" && newPassword == "goodNewPassword");
            }
        }

    }
}
