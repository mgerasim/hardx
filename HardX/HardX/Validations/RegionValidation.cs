using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HardX.Models;
using System.Globalization;
using System.Web.Mvc;

namespace HardX.Validations
{
    public class RegionValidationController : Controller
    {
        public JsonResult IsRegionName_Available(string Name)
        {
            Region model = new Region();
            int modelCount = model.GetAll("NAME = '" + Name + "'").Count;
            if (modelCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Район {0} уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}