using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TablesReady.Data.Domain;

namespace TablesReady.BLL
{
    public class RestaurantManager
    {
        public static List<Restaurant> GetAll()
        {
            var context = new Restaurants_EmployeesContext();
            var restaurant = context.Restaurant.OrderBy(r => r.RestaurantName).ToList();
            return restaurant;
        }

        public static void Add(Restaurant restaurant)
        {
            var context = new Restaurants_EmployeesContext();
            context.Restaurant.Add(restaurant);
            context.SaveChanges();
        }

        public static void update(Restaurant restaurant)
        {
            var context = new Restaurants_EmployeesContext();
            var firstRestaurant = context.Restaurant.Find(restaurant.RestaurantId);
            firstRestaurant.RestaurantName = restaurant.RestaurantName;
            firstRestaurant.RestaurantBusinessNum = restaurant.RestaurantBusinessNum;
            firstRestaurant.RestaurantSignUpDate = restaurant.RestaurantSignUpDate;
            context.SaveChanges();

        }

        public static Restaurant Find(int RestaurantID)
        {
            var context = new Restaurants_EmployeesContext();
            var restaurant = context.Restaurant.Find(RestaurantID);
            return restaurant;


        }

        public static IList GetAsKeyValuePairs()
        {
            var context = new Restaurants_EmployeesContext();
            var details = context.Restaurant.Select(b => new
            {
                Key = b.RestaurantId,
                Value = b.RestaurantName
            }).ToList();
            return details;
        }
    }
}
