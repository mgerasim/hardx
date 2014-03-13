using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace HardX.Controllers
{
    public class UserValidationController : Controller
    {
        public JsonResult IsUserLogin_Available(string Login)
        {
            HardX.Models.User theUser = new HardX.Models.User();
            int userCount = theUser.GetAll("UPPER(LOGIN) = '" + Login.ToUpper() + "'").Count;
            if (userCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Пользователь с логином '{0}' уже существует.", Login);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public JsonResult IsUserName_Available(string Name)
        {
            HardX.Models.User theUser = new HardX.Models.User();
            int userCount = theUser.GetAll("NAME = '" + Name + "'").Count;
            if (userCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Пользователь с имененем '{0}' уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
