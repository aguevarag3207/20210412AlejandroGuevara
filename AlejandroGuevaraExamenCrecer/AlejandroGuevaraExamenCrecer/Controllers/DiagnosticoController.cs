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
    public class DiagnosticoController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] Models.ModelDiagnostico diagnostico)
        {
            Data.DataDiagnostico ndiagnostico = new Data.DataDiagnostico();
            var resp = ndiagnostico.NuevoDiagnostico(diagnostico);
            return Ok(resp);
        }

        
    }
}
