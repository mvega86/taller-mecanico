using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace taller_mecanico.Domain.DTOs
{
    public class CustomerDTO
    {
        public Guid Id{ get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "BirthDay Required")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Phone Number Required")]
        [Phone]
        public string PhoneNumber { get; set; }

        public string FullName => $"{Name} {LastName}";
    }
}
