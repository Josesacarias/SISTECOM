using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Supplier
    {

        public int IdSupplier { get; set; }
        public string Name { get; set;}
        public string Nit { get; set;}
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string AccountNumber1 { get; set; }
        public string AccountNumber2 { get; set; }
        public string AccountNumber3 { get; set; }
        public DateTime DateRegistration { get; set; }
        public string PaymentMethod { get; set; }
        public string Bank_1 { get; set; }
        public string Bank_2 { get; set; }
        public string Bank_3 { get; set; }
        public decimal Discounts { get; set; }
        public string PaymentAgreement { get; set; }



    }
}
