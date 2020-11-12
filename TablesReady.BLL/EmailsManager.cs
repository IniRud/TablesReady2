using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TablesReady.Data.Domain;

namespace TablesReady.BLL
{
    public class EmailsManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new Restaurants_EmployeesContext();
            var details = context.Email.Select(b => new
            {
                b.EmaiId,
                b.EmailAddress
            }).ToList();
            return details;
        }
    }
}
