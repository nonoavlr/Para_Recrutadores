using System;
using System.Collections.Generic;
using System.Text;

namespace Loja
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressType { get; set; }
        public string AddressName { get; set; }
        public string Number { get; set; }
        public string Complemention { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
