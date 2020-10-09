using System;
using System.Collections.Generic;

namespace DBTestLib
{
    public partial class Lineitem
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int Productid { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Request Request { get; set; }
    }
}
