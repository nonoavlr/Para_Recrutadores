using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Loja
{
    public class Order
    {
        public int OrderID { get; set; }
        public virtual List<Product> Products { get; set; }
        public string TypePayment { get; set; }
        public double Total { get => Total; set => Products.Sum(x => x.Price); }
        public int AddressID { get; set; }
        public virtual Address AddressShip { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
