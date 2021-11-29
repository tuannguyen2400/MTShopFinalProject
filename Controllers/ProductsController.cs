using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite_SaleManagement_.Models;


namespace MyWebsite_SaleManagement_.Controllers

{
    public class ProductsController : Controller
    {
        SaleManagementEntities db = new SaleManagementEntities();
        // Create 2 PartialView Product1 and 2 to show product with 2 diffirence style
        // GET: Products
        public ActionResult Product1()
        {
            var ListProducts = db.Products;
            ViewBag.ListProduct = ListProducts;
            return View();

        }
        // GET: Products
        public ActionResult ProductPartial()
        {
            return PartialView();
        }
        public ActionResult ProductPartial1()
        {
            return PartialView();

        }
    }
}

