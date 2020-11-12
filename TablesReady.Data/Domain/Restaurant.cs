using System;
using System.Collections.Generic;

namespace TablesReady.Data.Domain
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            AddressDetails = new HashSet<AddressDetails>();
            Email = new HashSet<Email>();
            Employee = new HashSet<Employee>();
            Phonebook = new HashSet<Phonebook>();
        }

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantBusinessNum { get; set; }
        public DateTime RestaurantSignUpDate { get; set; }

        public virtual ICollection<AddressDetails> AddressDetails { get; set; }
        public virtual ICollection<Email> Email { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Phonebook> Phonebook { get; set; }
    }
}
