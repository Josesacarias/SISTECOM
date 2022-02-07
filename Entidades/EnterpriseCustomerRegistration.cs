using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EnterpriseCustomerRegistration
    {
        public int EnterpriseClientId { get; set; }
        public DateTime RegistrationTime { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string CustomerType { get; set; }
        public string Agency { get; set; }
        public string Dpi { get; set; }
        public string Nit { get; set; }
        public string Trade_Name { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string FullAddress { get; set; }
        public string Zone { get; set; }
        public string Colony { get; set; }
        public string Residential { get; set; }
        public string Village { get; set; }
        public string Department { get; set; }
        public string Municipality { get; set; }
        public string Country { get; set; }
        public string CellPhone { get; set; }
        public string TelephoneResidencial { get; set; }
        public string Service_Type { get; set; }
        public DateTime InstalationDate { get; set; }
    }
}
