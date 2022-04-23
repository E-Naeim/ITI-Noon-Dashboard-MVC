using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Phone
    {
        // By default id is primary and auto incremented
        public int Id { get; set; }

        [MaxLength(11)]
        [RegularExpression("([0-9]+)")]
        public string PhoneNumber { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
