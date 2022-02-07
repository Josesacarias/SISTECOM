using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PurchaseOrderRegistration
    {
        public int Purchase_Order_Id { get; set; }
        public string Applicant_Name { get; set; }
        public string Product_Requested { get; set; }
        public int Quantity { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }
        public int Unit_Price { get; set; }
        public int Total_Price { get; set; }
        public string Payment_Agreement { get; set; }

        public string CurrencyType { get; set; }
        public string LaboredBy { get; set; }
        public string DispatchAddress { get; set; }
        public decimal Discounts { get; set; }
        public int PaymentDeadline {get; set; }
        public decimal AdvancePayment {get; set; }
        public string PaymentType { get; set; }
        public DateTime DateOfPurchase { get; set; }














    }
}
