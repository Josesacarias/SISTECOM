using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductOutputWinery
    {
        public int OutputId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string ReasonForDeparture { get; set; }
        public string Description { get; set; }
        public decimal Unit_Measure { get; set; }
        public decimal Agency { get; set; }
        public string PersonWhoReceives { get; set; }

    }
}
