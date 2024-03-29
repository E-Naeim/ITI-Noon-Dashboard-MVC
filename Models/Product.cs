﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        // By default id is primary and auto incremented
        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string NameArabic { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string DescriptionArabic { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Weight { get; set; }

        public float Discount { get; set; }

        public bool IsActive { get; set; }

        public DateTime AddedOn { get; set; }

        // Each Product has a collection of Images
        [Required]
        public ICollection<Image> Images { get; set; }

        // Each Product is sold by a collection of Sellers
        [ForeignKey("Seller")]
        public int SellerID { get; set; }
        public User Seller { get; set; }

        // Each Product has a collection of reviews
        public ICollection<Review> Reviews { get; set; }

        public ICollection<Likes> Likes { get; set; }

        public ICollection<Wishlist> Wishlists { get; set; }

        // Each Product can be in many Orders
        public ICollection<OrderItem> Orders { get; set; }

        public ICollection<Cart> Carts { get; set; }

        // Each Product is related to One Category
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public Product()
        {
            AddedOn = DateTime.Now;
        }
    }
}
