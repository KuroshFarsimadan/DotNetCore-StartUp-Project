using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Entities
{
    /*
     * For each order, we can have 1 or more products associated to it. 
     * We can have 1 or more quantity per product in an order
     */
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderReferenceNumber { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
