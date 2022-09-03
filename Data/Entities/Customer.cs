using taller_mecanico.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace taller_mecanico.Data.Entities
{
    public class Customer: EntityBase
    {
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
    }
}
