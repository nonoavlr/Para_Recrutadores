using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain
{
    public class Database
    {
        public int DatabaseID { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }
    }
}
