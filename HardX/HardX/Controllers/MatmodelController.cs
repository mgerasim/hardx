using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;

namespace HardX.Controllers
{
    public class MatmodelController : Controller
    {
        //
        // GET: /Matmodel/

        public ActionResult Index()
        {
            List<Matmodel> theListMatmodel = new List<Matmodel>();
            Matmodel theMatmodel = new Matmodel();
            theListMatmodel = (List<Matmodel>)theMatmodel.GetAll();

            return View(theListMatmodel);
        }

        public ActionResult Compatibility(int ID)
        {
            Matmodel model = new Matmodel();
            model = model.GetById(ID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Compatibility(int ID, FormCollection collection)
        {
            Matmodel model = new Matmodel();
            model = model.GetById(ID);

            string IDs = collection["DevmodelSelections"];

            foreach (string item in IDs.Split(','))
            {
                model.Devmodels.Add((new Devmodel()).GetById(Convert.ToInt32(item)));
            }

            model.Update(model);

            return View(model);
        }

    }
}
