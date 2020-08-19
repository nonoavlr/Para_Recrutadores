using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain
{
    public class Item
    {
        public int ItemID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Amount { get { return this.Product.Price * this.Quantity; } }
    }
}
