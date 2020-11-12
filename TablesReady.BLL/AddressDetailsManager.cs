using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TablesReady.Data.Domain;

namespace TablesReady.BLL
{
    public class AddressDetailsManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new Restaurants_EmployeesContext();
            var details = context.AddressDetails.Select(b => new
            {
                b.AddressId,
                b.StreetName
            }).ToList();
            return details;
        }
    }
}
