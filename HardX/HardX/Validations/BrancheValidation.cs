using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using System.Globalization;

namespace HardX.Controllers
{
    public class BranchValidationController : Controller
    {
        public JsonResult IsBrancheFullName_Available(string FullName)
        {
            Branche theBranche = new Branche();
            int brancheCount = theBranche.GetAll("NAME = '" + FullName + "'").Count;
            if (brancheCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Филиал {0} уже существует.", FullName);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public JsonResult IsBrancheShortName_Available(string ShortName)
        {
            Branche theBranche = new Branche();
            int brancheCount = theBranche.GetAll("S_NAME = '" + ShortName + "'").Count;
            if (brancheCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Филиал {0} уже существует.", ShortName);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
