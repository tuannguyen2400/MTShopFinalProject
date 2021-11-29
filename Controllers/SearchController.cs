using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite_SaleManagement_.Models;

namespace MyWebsite_SaleManagement_.Controllers
{
    public class SearchController : Controller
         
    {
        SaleManagementEntities db = new SaleManagementEntities();
        // GET: Search
        public ActionResult ResultResearch(string sKeyword)
        {
            var lstProduct = db.Products.Where(n => n.NameProduct.Contains(sKeyword));
            return View(lstProduct.OrderBy(n => n.NameProduct));
        }
    }
}