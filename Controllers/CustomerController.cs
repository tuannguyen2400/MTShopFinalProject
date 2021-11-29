using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebsite_SaleManagement_.Models;



namespace MyWebsite_SaleManagement_.Controllers
{
    public class CustomerController : Controller
    {
        // Truy vấn dữ liêu thông qua câu lệnh 
        // Đổi lstKH sẽ lấy toàn bộ dữ liệu  từ bản khách hàng


        SaleManagementEntities db = new SaleManagementEntities();
        public ActionResult Index()
        {
            // lấy dữ liệu là một danh sách khách hàng
            // var listKH = from KH in db.Customers select KH;
            //Dùng phương thúc hỗ trợ sẵn
            var listKH = db.Customers;
            return View(listKH);
        }
        public ActionResult Index1()
        {
            var listKH = from KH in db.Customers select KH;
            return View(listKH);
        }
        public ActionResult TruyVanMotDoiTuong()
        {
            // Truy van 1 doi tuong
            // Step 1 : lay ra danh sach khach hang`
            //var listKH = from KH in db.Customers where KH.CustomerCode==1 select KH; ;
            // Step 2 
            // Customer customers = listKH.FirstOrDefault();
            Customer customers = db.Customers.SingleOrDefault(n=>n.CustomerCode==2);
            return View(customers);

        }
        public ActionResult SortDuLieu()
        {
            // phuong thuc sap xep du lieu
            List<Customer> ListKH = db.Customers.OrderBy(n => n.NameCustomer).ToList();
            return View(ListKH);

        }
        public ActionResult GroupData()
        {
            // phuong thuc sap xep du lieu
            List<Member> ListKH = db.Members.OrderBy(n => n.Account).ToList();
            return View(ListKH);

        }

    }
}