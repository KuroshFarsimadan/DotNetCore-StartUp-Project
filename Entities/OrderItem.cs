using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal ProductBatchPrice { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
