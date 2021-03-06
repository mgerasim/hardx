﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using HardX.Utils;
using System.Net.Mail;

namespace HardX.Controllers
{
    public class ShippingController : Controller
    {
        //
        // GET: /Shipping/

        public ActionResult Index()
        {
            if (!Access.HasAccess(71))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }

            Shipping model = new Shipping();
            List<Shipping> theListModel = new List<Shipping>();
            theListModel = (List<Shipping>)model.GetAll("","ID DESC");

            return View(theListModel);
        }

        //
        // GET: /Shipping/Details/5

        public ActionResult Details(int id)
        {
            if (!Access.HasAccess(74))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            return View();
        }

        public ActionResult CreateAjax(string name)
        {
            if (!Access.HasAccess(72))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping theShipping = new Shipping();
            theShipping.Name = name;
            theShipping.Save(theShipping);

            return View(theShipping);
        }

        //
        // GET: /Shipping/Create

        public ActionResult Create()
        {
            if (!Access.HasAccess(72))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            ShippingNew model = new ShippingNew();
            return View(model);
        } 

        //
        // POST: /Shipping/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!Access.HasAccess(72))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Shipping model = new Shipping();
                model.Name = collection["Name"];
                model.Save(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Shipping/Edit/5
 
        public ActionResult Edit(int id)
        {
            if (!Access.HasAccess(73))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);

            ViewBag.Devmodels = (new Devmodel()).GetAll();
            ViewBag.Matmodels = (new Matmodel()).GetAll();

            return View(model);
        }

        //
        // POST: /Shipping/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!Access.HasAccess(13))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Shipping model = new Shipping();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.Update(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Distribute(int id)
        {
            if (!Access.HasAccess(73))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);

            ViewBag.Stores = (new Store()).GetAll("ID in (147, 84, 145, 81, 22, 121)");
            ViewBag.Distributes = (new Shippingitemdistribute()).GetAll();

            return View(model);
        }

        //

        [HttpPost]
        public ActionResult Distribute(int id, FormCollection collection)
        {
            if (!Access.HasAccess(13))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            try
            {
                Shipping model = new Shipping();
                model = model.GetById(id);
                model.Name = collection["Name"];
                model.Update(model);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DistributeSave(int id)
        {
            if (!Access.HasAccess(73))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);

            foreach (var item in model.Shippingitems)
            {
                foreach(var distr in (new Shippingitemdistribute()).GetAll("STATUS=1 AND SHIPPINGITEM_ID="+item.ID.ToString()))
                {
                    distr.Status = 2;
                    distr.Update(distr);
                }
            }
            SendEmailNotification(id);
            return View(model);
        }

        void SendEmailNotification(int shipping_id) {
            IEnumerable<string> shippingitem_numbers = (new Shippingitem()).GetAll("SHIPPING_ID=" + shipping_id.ToString()).Select(a => a.ID.ToString());
            string str_shippingitem_numbers = string.Join(", ", shippingitem_numbers);

            IEnumerable<string> storeid_numbers = (new Shippingitemdistribute()).GetAll("SHIPPINGITEM_ID in (" + str_shippingitem_numbers + ")").Select(a => a.StoreID.ToString()).Distinct();
            string str_storeid_numbers = string.Join(", ", storeid_numbers);

            foreach(var store in (new Store()).GetAll( "ID in ("+str_storeid_numbers+")" )){
                string strEmail = "";
                string strEmail2 = "";
                if (store.User != null)
                {
                    strEmail = store.User.Email;
                }

                if (store.User2 != null)
                {
                    strEmail2 = store.User2.Email;
                }

                string strMsg = "";
                strMsg = "<b>Новое поступление на склад " + store.Name + "</b><br/><br/><br/>";                
                strMsg += "<table class=\"table table-bordered\">";
                string strDistribute="";
                foreach (var distribute in (new Shippingitemdistribute()).GetAll( "STATUS=2 AND STORE_ID="+ store.ID +" AND SHIPPINGITEM_ID in ("+str_shippingitem_numbers+")" ))
                {
                    strDistribute += "<tr>";
                    string str="";
                    Shippingitem theShippingitem = new Shippingitem();
                    theShippingitem = theShippingitem.GetById(distribute.ShippingitemID);
                    if (theShippingitem.Devmodel != null)
                    {
                        str += "<td>" + theShippingitem.Devmodel.FullName + "</td>";
                        str += "<td>" + distribute.Count + "</td>";
                    }
                    if (theShippingitem.Matmodel != null)
                    {

                        str += "<td>" + theShippingitem.Matmodel.FullName + "</td>";
                        str += "<td>" + distribute.Count + "</td>";
                    }

                    strDistribute += str;
                    strDistribute += "</tr>";
                }
               
                if (strDistribute.Length > 0)
                {
                    strMsg += strDistribute + "</table>"+" <p><a href=\"http://hardx.dv.rt.ru/Shippingitemdistribute/details\">Смотреть</a></p> ";
                    
                    try
                    {
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("10.198.1.200");

                        mail.From = new MailAddress("hardx@dv.rt.ru");
                        mail.To.Add(strEmail);
                        mail.To.Add(strEmail2);
                        mail.Subject = "Склад поступление";
                        mail.IsBodyHtml = true;
                        mail.Body = strMsg;

                        SmtpServer.Port = 25;
                        SmtpServer.EnableSsl = false;

                        SmtpServer.Send(mail);

                    }
                    catch (Exception ex)
                    {

                    }  
                }
            }
                
        }

        //
        // GET: /Shipping/Delete/5
 
        public ActionResult Delete(int id)
        {
            if (!Access.HasAccess(75))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);
            model.Delete(model);

            return RedirectToAction("Index");
        }

        //
        // POST: /Shipping/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!Access.HasAccess(75))
            {
                System.Web.Routing.RouteValueDictionary route = new System.Web.Routing.RouteValueDictionary();
                route.Add("err", "Нет доступа!");
                return RedirectToAction("Error", "Home", route);
            }
            Shipping model = new Shipping();
            model = model.GetById(id);
            model.Delete(model);
            

            return RedirectToAction("Index");
        }
    }
}
