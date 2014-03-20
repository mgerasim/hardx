using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using System.Globalization;

namespace HardX.Validations
{
    public class StateValidationController : Controller
    {
        public JsonResult IsStateName_Available(string Name)
        {
            State model = new State();
            int modelCount = model.GetAll("NAME = '" + Name + "'").Count;
            if (modelCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Регион {0} уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}