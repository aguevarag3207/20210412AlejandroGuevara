using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroGuevaraExamenCrecer.Models
{
    public class ModelDiagnostico
    {
        public int iddiagnostico { get; set; }
        public int paciente { get; set; }
        public int medico { get; set; }
        public string diagnostico { get; set; }
        public string receta { get; set; }
        public int fechaconsulta { get; set; }
        public int estado { get; set; }
    }
}
