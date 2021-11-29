using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite_SaleManagement_.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;



namespace MyWebsite_SaleManagement_.Controllers
{
    public class HomeController : Controller
    {
        SaleManagementEntities db = new SaleManagementEntities();

        // GET: Home
        public ActionResult Index()
        {
            var ListMenProduct = db.Products.Where(n => n.ProductTypeCode == 1 && n.NewProduct == 1 && n.Deleted == false);
            ViewBag.ListMenProduct = ListMenProduct;
            var ListWomenProduct = db.Products.Where(n => n.ProductTypeCode == 2 && n.NewProduct == 1 && n.Deleted == false);
            ViewBag.ListWomenProduct = ListWomenProduct;

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Question = new SelectList(LoadQuestion());
            return View();
        }
        [HttpPost]
        public ActionResult Register(Member thanhvien,FormCollection f)
        {
            ViewBag.Question = new SelectList(LoadQuestion());

            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Notification = "Create Success";
                    db.Members.Add(thanhvien);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Notification = "Create Failed";
                }
                return View();
            }
            ViewBag.Notification = "Failed Please Input Again";
            return View();
        }
        public List<String> LoadQuestion()
        {
            List<String> lstQuestion = new List<string>();
            lstQuestion.Add("What is your hobbies");
            lstQuestion.Add("Do you have pet");
            lstQuestion.Add("What do you do at weekend");
            return lstQuestion;
        }

        public ActionResult Login(FormCollection f)
        {

            string sAccount = f["USERNAME"].ToString();
            string sPassword = f["Password"].ToString();
            Member thanhvien = db.Members.SingleOrDefault(n => n.Account == sAccount && n.Password == sPassword);

            if (thanhvien != null)
            {
                Session["Account"] = thanhvien;
                return RedirectToAction("Index");
            }
            return Content("Invalid account or password !");
        }
        public ActionResult LogOUt()
        {
            Session["Account"] = null;
            return RedirectToAction("Index");
        }
    }
}