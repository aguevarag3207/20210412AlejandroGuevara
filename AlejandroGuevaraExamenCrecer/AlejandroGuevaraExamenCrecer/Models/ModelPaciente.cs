using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroGuevaraExamenCrecer.Models
{
    public class ModelPaciente
    {
        public int idpaciente { get; set; }
        public string paciente { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int estado { get; set; }
    }
}
