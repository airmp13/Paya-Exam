using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Price { get; set; }

        public bool IsFragile { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
