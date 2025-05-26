using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        [Length(11,11)]
        public string PhoneNumber { get; set; }
    


        public ICollection<Order> Orders { get; set; }
    }
}
