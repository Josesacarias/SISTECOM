using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class WarehouseProductEntry
    {
        public int EntryId { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public int Description { get; set; }
        public string SkuCode { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Unit_Measure { get; set; }
        public DateTime DateEntry { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
    }
}
