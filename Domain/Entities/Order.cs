using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
        
        [Required]
        public DeliveryMethod DeliveryMethod { get; set; }

        public int TotalPrice { get; set; }


        public User user { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
