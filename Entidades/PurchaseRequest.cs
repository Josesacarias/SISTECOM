using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PurchaseRequest
    {
        public int RequestId { get; set; }
        public string RequestName { get;}
        public string ApplicantName { get; set; }
        public string Dpi { get; set; }
        public DateTime Delivery_Date { get; set; }
        public DateTime RequestDate { get; set; }
        public string Product_Requested { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }




    }
}
