using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebsite_SaleManagement_.Controllers
{
    public class DemoAjaxController : Controller
    {
        // GET: DemoAjax
        public ActionResult DemoAjax()
        {
            return View();
        }
        
        public ActionResult LoadAjaxActionLink()
        {
            System.Threading.Thread.Sleep(2000);
            return Content("Hello Ajax");
        }
        public ActionResult LoadAjaxBeginForm(FormCollection f )
        {
            string RESULT = f["txt1"].ToString();
            return Content("RESULT");



        }
        public ActionResult LoadAjaxJquery(int a, int b)
        {
            return Content((a + b).ToString());
        }

    }
}