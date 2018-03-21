using CloudTraceability.Core;
using Rafy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloudTraceability.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var customer = RF.ResolveInstance<CustomerRepository>().GetFirst();

            if (customer != null)
                ViewBag.Title = "Home Page" + customer.CustomerName;
            else
                ViewBag.Title = "Home Page";

            return View();
        }
    }
}
