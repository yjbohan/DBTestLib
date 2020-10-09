using System;
using System.Collections.Generic;

namespace DBTestLib
{
    public partial class Vendor
    {
        public Vendor()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
