using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Commands
{
    public class AddProductCommand : IRequest<bool>
    {

		[MaxLength(100)]
		public string Name { get; set; }

		[Range(0, int.MaxValue)]
		public int Price { get; set; }

		public bool IsFragile { get; set; }
	}
}
