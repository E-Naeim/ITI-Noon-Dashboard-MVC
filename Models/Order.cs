using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        // By default id is primary and auto incremented
        public int Id { get; set; }

        // Each Order is made by one Customer
        public int CustoemerId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsPaid { get; set; }

        public decimal Discount { get; set; }

        public string DeliveryStatus { get; set; }

        // Each Order has a collection of OrderDetails
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }
}
