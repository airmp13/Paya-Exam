using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class AddUserCommand : IRequest<bool>
    {
        [MaxLength(100)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        [Length(11, 11),Phone]
        public string PhoneNumber { get; set; }
    }
}
