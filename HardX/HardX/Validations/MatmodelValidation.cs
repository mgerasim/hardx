using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using System.Globalization;

namespace HardX.Controllers
{
    public class MatmodelValidationController : Controller
    {
        public JsonResult IsMatmodelName_Available(string Name)
        {
            Matmodel model = new Matmodel();
            int modelCount = model.GetAll("NAME = '" + Name + "'").Count;
            if (modelCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Расходный материал {0} уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}
