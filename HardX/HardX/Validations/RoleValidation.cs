using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using HardX.Models;

namespace HardX.Controllers
{
    public class RoleValidationController : Controller
    {
        public JsonResult IsRoleName_Available(string Name)
        {
            Role theRole = new Role();
            int roleCount = theRole.GetAll("NAME = '" + Name + "'").Count;
            if (roleCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Роль '{0}' уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }

    }
}
