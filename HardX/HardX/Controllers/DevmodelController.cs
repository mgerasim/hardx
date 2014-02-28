using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.ViewModels;

namespace HardX.Controllers
{
    public class DevmodelController : Controller
    {
        //
        // GET: /Devmodel/

        public ActionResult Index()
        {
            List<Devmodel> theListDevmodel = new List<Devmodel>();
            Devmodel theDevmodel = new Devmodel();
            theListDevmodel = (List<Devmodel>)theDevmodel.GetAll();

            return View(theListDevmodel);
        }


        public ActionResult Compatibility(int ID)
        {
            Devmodel model = new Devmodel();
            model = model.GetById(ID);

            return View(new DevmodelInput()
                {
                    TheDevmodel = model,
                    MatmodelSelections = (List<Matmodel>)(new Matmodel()).GetAll(),
                    SelectedMatmodel = model.Matmodels.Select(x => x.ID).ToList()
                });
        }

        [HttpPost]
        public ActionResult Compatibility(int ID, FormCollection collection)
        {
            Devmodel model = new Devmodel();
            model = model.GetById(ID);

            string IDs = collection["MatmodelSelections"];
                        
            foreach (string item in IDs.Split(','))
            {
                model.Matmodels.Add((new Matmodel()).GetById(Convert.ToInt32(item)));
            }

            model.Update(model);

            return View(new DevmodelInput()
            {
                TheDevmodel = model,
                MatmodelSelections = (List<Matmodel>)(new Matmodel()).GetAll(),
                SelectedMatmodel = model.Matmodels.Select(x => x.ID).ToList()
            });
        }

    }
}
