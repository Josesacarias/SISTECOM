using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RegisterProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }
        public string SkuCode { get; set; }
        public string SupplierCode { get; set; }
        public string Description { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Unit_Measure { get; set; }
        public decimal Tax { get; set; }
        public string Supplier { get; set; }
        public string ClasisificationProduct { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Maximum_Product { get; set; }
        public decimal SalePrice { get; set; }
    }
}
