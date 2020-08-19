using Loja.Domain;
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
        public virtual List<Item> Items { get; set; }
        public string TypePayment { get; set; }
        public double Total { get { return this.Items.Sum(c => c.Amount); } }
        public int AddressID { get; set; }
        public virtual Address AddressShip { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
