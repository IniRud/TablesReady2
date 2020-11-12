using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesReady.PageApp.Models;

namespace TablesReady.PageApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } 
    }
}

/// <summary>
/// Class is responsible for authentication and user management
/// </summary>

public class UserManager
{
    private readonly static List<User> _users;

    static UserManager()
    {
        _users = new List<User>();
        _users.Add(new User { Id = 1, Username = "sean", Password = "password", FullName = " Sean Burman", Role = "Manager"});
        _users.Add(new User { Id = 1, Username = "michael", Password = "password", FullName = " Michael Barry", Role = "staff" });

    }
    /// <summary>
    /// user is authenticated based on credentials and a user returned if exists or null if not 
    /// </summary>
    /// <param name="username"> username as string </param>
    /// <param name="password"> password as string</param>
    /// <returns>returns a user object or null</returns>
    public static User Authenticate(string username,string password)
    {
        var user = _users.SingleOrDefault(usr => usr.Username == username && usr.Password == password);
        return user; // this will return a null or an object
    }
}