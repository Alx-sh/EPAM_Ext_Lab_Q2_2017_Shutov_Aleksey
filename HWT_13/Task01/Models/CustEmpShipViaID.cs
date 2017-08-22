using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task01
{
    public class CustEmpShipViaID
    {
        public List<string> CustomerListID = new List<string>();
        public List<int> EmployeeListID = new List<int>();
        public List<int> ShipViaListID = new List<int>();
        public string shipVia { get; set; }
        public string custID { get; set; }
        public string empID { get; set; }
        [Required]
        public string ShipName { get; set; }
    }
}