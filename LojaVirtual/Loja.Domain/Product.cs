using System.Collections.Generic;

namespace Loja
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int OrderID { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public virtual Order Order { get; set; }
    }
}