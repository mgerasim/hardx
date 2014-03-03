using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using System.Globalization;

namespace HardX.Controllers
{
    public class DevmodelValidationController : Controller
    {
        public JsonResult IsDevmodelName_Available(string Name)
        {
            Devmodel model = new Devmodel();
            int modelCount = model.GetAll("NAME = '" + Name + "'").Count;
            if (modelCount > 0)
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Оборудование {0} уже существует.", Name);
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);

        }

        public JsonResult IsNumber_Available(string Number)
        {
            try
            {
                int i = Convert.ToInt32(Number);
            }
            catch 
            {
                string suggestedUID = String.Format(CultureInfo.InvariantCulture,
                    "Вводите целое число.");
                return Json(suggestedUID, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
