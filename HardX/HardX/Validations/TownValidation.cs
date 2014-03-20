using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Validations
{
    public class TownValidationController : Controller
    {
        public JsonResult IsTownName_Available(string Name)
        {
            Town model = new Town();
            int modelCount = model.GetAll("NAME = '" + Name + "'").Count;
            if (modelCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Населённый пункт {0} уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}