﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
        // By default id is primary and auto incremented
        public int Id { get; set; }

        // Each Review is given by one customer
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        // Each Review is given for one specific Product
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Required]
        public decimal Rate { get; set; }
    }
}
