using System;
using System.Collections.Generic;

namespace TablesReady.Data.Domain
{
    public partial class Employee
    {
        public Employee()
        {
            AddressDetails = new HashSet<AddressDetails>();
            Email = new HashSet<Email>();
            Phonebook = new HashSet<Phonebook>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<AddressDetails> AddressDetails { get; set; }
        public virtual ICollection<Email> Email { get; set; }
        public virtual ICollection<Phonebook> Phonebook { get; set; }
    }
}
