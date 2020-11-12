using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesReady.Data.Domain;

namespace TablesReady.PageApp.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
       // public DateTime HireDate { get; set; }
        public string Restaurant { get; set; }
       //public virtual Restaurant Restaurant { get; set; }
    }
}
