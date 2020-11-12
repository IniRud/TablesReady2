using System;
using System.Collections.Generic;
using System.Text;
using TablesReady.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TablesReady.BLL
{
    public class EmployeeManager
    {
        public static List<Employee> GetAll()
        {
            var context = new Restaurants_EmployeesContext();
            var emp = context.Employee.Include(e => e.Restaurant).Include(b => b.Phonebook).Include(b => b.Email).ToList();
            
            return emp;
        }

        public static void Add(Employee employee)
        {
            var context = new Restaurants_EmployeesContext();
            context.Employee.Add(employee);
            context.SaveChanges();
        }
    }
}
