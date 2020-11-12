using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TablesReady.Data.Domain;

namespace TablesReady.BLL
{
    public class PhonebookManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new Restaurants_EmployeesContext();
            var details = context.Phonebook.Select(b => new
            {
                b.PhoneId,
                b.PhoneNumber
            }).ToList();
            return details;
        }
    }
}
