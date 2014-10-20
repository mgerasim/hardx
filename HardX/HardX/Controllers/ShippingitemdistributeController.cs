﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HardX.Models;
using System.Net.Mail;

namespace HardX.Controllers
{
    public class ShippingitemdistributeController : Controller
    {
        //
        // GET: /Shippingitendistribute/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int shippingitem_id, int store_id, int count)
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("10.198.1.200");

                mail.From = new MailAddress("hardx@dv.rt.ru");
                mail.To.Add("gerasimovmn@dv.rt.ru");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from HARDX";

                SmtpServer.Port = 25;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                
            }
            catch (Exception ex)
            {
                
            }

            Shippingitemdistribute theModel = new Shippingitemdistribute();
            theModel.ShippingitemID = shippingitem_id;
            theModel.StoreID = store_id;
            theModel.Status = 1;
            theModel.Count = count;
            if ((new Shippingitemdistribute()).GetAll("SHIPPINGITEM_ID=" + shippingitem_id.ToString() + " AND STORE_ID=" + store_id.ToString()).Count > 0)
            {
                Shippingitemdistribute theUpdate = (new Shippingitemdistribute()).GetAll("SHIPPINGITEM_ID=" + shippingitem_id.ToString() + " AND STORE_ID=" + store_id.ToString())[0];
                theUpdate.ShippingitemID = shippingitem_id;
                theUpdate.StoreID = store_id;
                theUpdate.Count = count;
                theUpdate.Update(theUpdate);
                theUpdate.Status = 1;
                return View(theUpdate);
            }
            else
            {
                theModel.ShippingitemID = shippingitem_id;
                theModel.StoreID = store_id;
                theModel.Count = count;
                theModel.Save(theModel);
                return View(theModel);
            }

            
        }

    }
}
