using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using HardX.Models;

namespace HardX.Controllers
{
    public class StoreValidationController : Controller
    {
        public JsonResult IsStoreName_Available(string Name)
        {
            Store model = new Store();
            int modelCount = model.GetAll("NAME = '" + Name + "'").Count;
            if (modelCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Склад {0} уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}
