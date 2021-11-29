using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebsite_SaleManagement_.Models;

namespace MyWebsite_SaleManagement_.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ItemShoppingCart
    {
        public int ProductCode { get; set; }
        public string NameProduct { get; set; }

        public int NumberOfOrder { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal intoMoney { get; set; }

        public string Image { get; set; }

        public ItemShoppingCart(int iProductCode)
        {
            using (SaleManagementEntities db = new SaleManagementEntities())
            {
                this.ProductCode = iProductCode;
                Product sp = db.Products.Single(n => n.ProductCode == iProductCode);
                this.NameProduct = sp.NameProduct;
                this.Image = sp.Image;
                this.UnitPrice = sp.UnitPrice;
                this.intoMoney = sp.UnitPrice * NumberOfOrder;
            }
            
        }
        public ItemShoppingCart(int iProductCode,int Number)
        {
            using (SaleManagementEntities db = new SaleManagementEntities())
            {
                this.ProductCode = iProductCode;
                Product sp = db.Products.Single(n => n.ProductCode == iProductCode);
                this.NameProduct = sp.NameProduct;
                this.Image = sp.Image;
                this.UnitPrice = sp.UnitPrice;
                this.NumberOfOrder = Number;
                this.intoMoney = sp.UnitPrice * NumberOfOrder;
            }

        }
    }
}
