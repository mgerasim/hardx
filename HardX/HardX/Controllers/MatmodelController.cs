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

    }
}
