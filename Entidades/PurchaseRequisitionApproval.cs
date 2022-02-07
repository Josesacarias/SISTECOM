using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PurchaseRequisitionApproval
    {
        public int ApprovalId { get; set; }
        public string Request_Name { get; set; }
        public string Applicant_Name { get; set; }
        public string Product_Requested { get; set; }
        public string Description { get; set; }

    }
}
