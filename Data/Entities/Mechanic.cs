using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taller_mecanico.Data.Entities.Base;

namespace taller_mecanico.Data.Entities
{
    public class Mechanic : EntityBase
    {
        public String FirstName { get; set; } = String.Empty;
        public String LastName { get; set; } = String.Empty;
        public String telephone { get; set; } = String.Empty;
    }
}