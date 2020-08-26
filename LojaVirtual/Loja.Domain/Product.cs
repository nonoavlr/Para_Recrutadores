using Loja.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Loja
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public List<StockSize> StockSize { get; set; }
        public virtual List<Database> Database { get; set; }
        public virtual List<Item> Items { get; set; }
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
    }
}