using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroGuevaraExamenCrecer.Models
{
    public class ModelCIta
    {
        public int idcita { get; set; }
        public int paciente { get; set; }
        public int medico { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int estado { get; set; }
    }
}
