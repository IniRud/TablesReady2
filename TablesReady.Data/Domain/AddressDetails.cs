using System;
using System.Collections.Generic;

namespace TablesReady.Data.Domain
{
    public partial class AddressDetails
    {
        public int AddressId { get; set; }
        public string StreetNum { get; set; }
        public string StreetName { get; set; }
        public string Country { get; set; }
        public string Prov { get; set; }
        public string City { get; set; }
        public string Postal { get; set; }
        public int? RestaurantId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
