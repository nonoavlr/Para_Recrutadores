using System;
using System.Collections.Generic;

namespace Loja
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
    }
}
