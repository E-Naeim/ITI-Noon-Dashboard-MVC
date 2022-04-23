using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Image
    {
        // By default id is primary and auto incremented
        public int Id { get; set; }

        [Required]
        public string ImageLink { get; set; }

        // Each Image is belonged to one Product
        public ICollection<Product> Product { get; set; }

        // Each Image is belonged to one Category
        public ICollection<Category> Category { get; set; }
    }
}
