using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TransferWarehouses
    {
        public int TransferId { get; set; }
        public string Product_Name { get; set; }
        public int Quantity { get; set; }
        public DateTime TransferDate { get; set; }
        public string ContainerWarehouse { get; set; }
        public string WineryDestination { get; set; }
        public string NameApplicator { get; set; }
        public string NameDisperser { get; set; }
        public string Description { get; set; }
    }
}
