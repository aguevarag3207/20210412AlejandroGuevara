using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlejandroGuevaraExamenCrecer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] Models.ModelCIta cita)
        {
            Data.DataCita ncita = new Data.DataCita();
            var resp = ncita.NuevaCita(cita);
            return Ok(resp);
        }
    }
}
