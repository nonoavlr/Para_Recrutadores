using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain
{
    public class StockSize
    {
        public int StockSizeID { get; set; }
        public int Stock { get; set; }
        public string Size { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
