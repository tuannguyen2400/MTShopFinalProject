using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite_SaleManagement_.Models;

namespace MyWebsite_SaleManagement_.Controllers
{
    public class ShoppingCartController : Controller
    {

        SaleManagementEntities db = new SaleManagementEntities();


        // GET: ShoppingCart

        //get Card
        public List<ItemShoppingCart> GetShoppingCart()
        {
            //shopping cart already exists
            List<ItemShoppingCart> lstshoppingCart = Session["ShoppingCart"] as List<ItemShoppingCart>;
            if (lstshoppingCart == null)
            {
                lstshoppingCart = new List<ItemShoppingCart>();
                Session["ShoppingCart"] = lstshoppingCart;
            }
            return lstshoppingCart;
        }
        //Add ShoppingCard normal (Load Type Page)
        public ActionResult AddShoppingCart(int ProductCode, string strURL)
        {
            // check product Database
            Product sp = db.Products.SingleOrDefault(n => n.ProductCode == ProductCode);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ItemShoppingCart> lstshoppingCart = GetShoppingCart();
            //Case 1 if the product exists in the cart
            ItemShoppingCart productCheck = lstshoppingCart.SingleOrDefault(n => n.ProductCode == ProductCode);
            if (productCheck != null)
            {
                if (sp.InventoryNumber < productCheck.NumberOfOrder)
                {
                    return View("Notifications");
                }
                productCheck.NumberOfOrder++;
                productCheck.intoMoney = productCheck.NumberOfOrder * productCheck.UnitPrice;
                return Redirect(strURL);
            }

            ItemShoppingCart itemSC = new ItemShoppingCart(ProductCode);
            if (sp.InventoryNumber < itemSC.NumberOfOrder)
            {
                return View("Notifications");
            }
            lstshoppingCart.Add(itemSC);
            return Redirect(strURL);
        }
        // Caculate the total amount of Product
        public double CalculateTheTotalAmount()
        {
            List<ItemShoppingCart> lstshoppingCart = Session["ShoppingCart"] as List<ItemShoppingCart>;
            if (lstshoppingCart == null)
            {
                return 0;
            }
            return lstshoppingCart.Sum(n => n.NumberOfOrder);
        }
        // Caculate total of Money
        public decimal CaculateTheTotalMoney()
        {
            List<ItemShoppingCart> lstshoppingCart = Session["ShoppingCart"] as List<ItemShoppingCart>;
            if (lstshoppingCart == null)
            {
                return 0;
            }
            return lstshoppingCart.Sum(n => n.intoMoney);
        }
        public ActionResult ReviewShoppingCart()
        {
            List<ItemShoppingCart> itemShoppingCarts = GetShoppingCart();
            return View();
        }
        public ActionResult ShoppingCartPartial()
        {
            if (CalculateTheTotalAmount() == 0)
            {
                ViewBag.AmountOfToTal = 0;
                ViewBag.AmountOfMoney = 0;
                return PartialView();
            }
            ViewBag.AmountOfToTal = CalculateTheTotalAmount();
            ViewBag.AmountOfMoney = CaculateTheTotalMoney();
            return PartialView();
        }
        // Edit Shopping Card
        [HttpGet]
        public ActionResult EditShoppingCart(int ProductCode)
        {
            if (Session["ShoppingCart"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            Product sp = db.Products.SingleOrDefault(n => n.ProductCode == ProductCode);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            // Get Lst Shopping Cart From Session
            List<ItemShoppingCart> lstshoppingCart = GetShoppingCart();

            ItemShoppingCart productCheck = lstshoppingCart.SingleOrDefault(n => n.ProductCode == ProductCode);
            if (productCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ShoppingCarts = lstshoppingCart;
            return View(productCheck);
        }
    }
}

   
    



 