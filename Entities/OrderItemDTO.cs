using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Entities
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal ProductBatchPrice { get; set; }
        public ProductDTO Product { get; set; }
        public OrderDTO Order { get; set; }

    }
}
