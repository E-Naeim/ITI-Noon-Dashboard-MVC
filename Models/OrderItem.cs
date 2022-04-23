using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OrderItem
    {
        // By default id is primary and auto incremented
        public int Id { get; set; }

        // Each OrderItem is related to one order
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }

        // Each Order is considered as buying a one Product
        [ForeignKey("product")]
        public int ProductID { get; set; }
        public Product product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
