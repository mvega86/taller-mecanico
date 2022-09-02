using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taller_mecanico.Models
{
    public class Client
    {
        public String dni { get; set; } = String.Empty;
        public String nombre { get; set; } = String.Empty;
        public String Apellidos { get; set; } = String.Empty;
        //public List<int> citas { get; set; }
    }
}