using System;
using System.Collections.Generic;

namespace DBTestLib
{//partial classes allows us to create a new class, Products. 'Partial Class Products 
    //if you change generated code, you lose your changes
    public partial class Product
    {
        public Product()
        {
            Lineitem = new HashSet<Lineitem>();
        }

        public int Id { get; set; }
        public int VendorId { get; set; }
        public string Partnumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }
        public string Photopath { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Lineitem> Lineitem { get; set; }

        
    }
}
