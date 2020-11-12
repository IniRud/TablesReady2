using System;
using System.Collections.Generic;

namespace TablesReady.Data.Domain
{
    public partial class Email
    {
        public int EmaiId { get; set; }
        public string EmailAddress { get; set; }
        public int RestaurantId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
