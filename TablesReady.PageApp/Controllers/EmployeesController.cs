using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TablesReady.BLL;
using TablesReady.Data.Domain;
using TablesReady.PageApp.Models;

namespace TablesReady.PageApp.Controllers
{
    public class EmployeesController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var emp = EmployeeManager.GetAll();
            var viewModels = emp.Select(e => new EmployeeViewModel 
            { 
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Middlename = e.Middlename,
                Position = e.Position,
                Restaurant = e.Restaurant.RestaurantName
                
            }).ToList();
            return View(viewModels);
        }

        public IActionResult Search()
        {
            ViewBag.Restaurant = GetRestaurant();
            return View();
        }

        public IActionResult Create()
        {
            //// call the restaurants get the collection of key value pairing objects
            //var restautant = RestaurantManager.GetAsKeyValuePairs();
            //// create a selection list items
            //var styles = new SelectList(restautant, "Key", "Value");
            ViewBag.RestaurantID = GetRestaurant();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                EmployeeManager.Add(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        protected IEnumerable GetRestaurant()
        {
            var restautant = RestaurantManager.GetAsKeyValuePairs();
            // create a selection list items
            var styles = new SelectList(restautant, "Key", "Value");
            return styles;
        }
    }
}
