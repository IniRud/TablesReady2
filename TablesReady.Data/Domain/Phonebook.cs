using System;
using System.Collections.Generic;

namespace TablesReady.Data.Domain
{
    public partial class Phonebook
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
        public int RestaurantId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
