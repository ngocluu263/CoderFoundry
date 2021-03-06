﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendGrid;
using mvcTesting0113.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;


namespace mvcTesting0113.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]

        public ActionResult Contact(Contact ContactForm)
        {
            var MyAddress = ConfigurationManager.AppSettings["ContactEmail"];
            var MyUsername = ConfigurationManager.AppSettings["Username"];
            var MyPassword = ConfigurationManager.AppSettings["Password"];

            if (ModelState.IsValid)
            {
                SendGridMessage mail = new SendGridMessage();
                mail.From = new MailAddress(ContactForm.Email);
                mail.AddTo(MyAddress);
                mail.Subject = ContactForm.Subject;
                mail.Text = ContactForm.Message;
                var credentials = new NetworkCredential(MyUsername, MyPassword);
                var transportWeb = new Web(credentials);
                transportWeb.Deliver(mail);
            }

            return View();
        }
    }
}