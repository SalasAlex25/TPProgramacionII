using CineBackend;
using CineBackend.Dominio;
using CineBackend.Servicio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CineWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesController : ControllerBase
    {
        private IServicio servicio; //punto de acceso a la API

        public ComprobantesController()
        {
            servicio = new Service();
        }
        
        //// GET: api/<ComprobantesController>
        //[HttpGet("/comprobantes")]
        //public IActionResult GetComprobantes()
        //{
        //    List<Comprobante> lst = null;
        //    try
        //    {
        //        //lst = servicio.Consulta_Comprobantes();
        //        return Ok(lst);

        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Error interno! Intente luego");
        //    }
        //}

        // GET api/<ComprobantesController>/5
        [HttpGet("{doc}")]
        public IActionResult Get(string doc)
        {
            if (String.IsNullOrEmpty(doc))
                return BadRequest("Doc. es requerido!");

            return Ok(servicio.DevolverDatos(doc));
        }

        // POST api/<ComprobantesController>
        //[HttpPost("consultar")]
        //public IActionResult GetPresupuesto(List<Parametro> lst)
        //{
        //    if (lst == null || lst.Count == 0)
        //        return BadRequest("Se requiere una lista de parámetros!");
            
        //    return Ok(servicio.Consulta_Comprobantes_Con_Filtro(lst));
        //}

        // POST api/<ComprobantesController>
        [HttpPost("GrabarCliente")]
        public IActionResult PostCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                bool result = servicio.InsertarUsuario(cliente);
                return Ok(result);
            }
            return BadRequest("Debe ingresar un cliente!");    
        }

        // PUT api/<ComprobantesController>/5
        [HttpPut("ModificarCliente")]
        public IActionResult PutCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                bool result = servicio.ModificarUsuario(cliente);
                return Ok(result);
            }
            return BadRequest("Debe ingresar un cliente!");
        }
        // PUT api/<ComprobantesController>/5
        [HttpPut("EliminarCliente")]
        public IActionResult PutBajaCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                bool result = servicio.EliminarUsuario(cliente);
                return Ok(result);
            }
            return BadRequest("Debe ingresar un cliente!");
        }

        // DELETE api/<ComprobantesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //NACHO 
        //[HttpGet("{doc}")]
        //public IActionResult GetComprobante(string doc)
        //{
        //    if (String.IsNullOrEmpty(doc))
        //        return BadRequest("Doc. es requerido!");

        //    return Ok(servicio.DevolverDatos(doc));
        //}

        // POST api/<ComprobantesController>
        //[HttpPost("consultar")]
        //public IActionResult GetPresupuestoComprobante(List<Parametro> lst)
        //{
        //    if (lst == null || lst.Count == 0)
        //        return BadRequest("Se requiere una lista de parámetros!");

        //    return Ok(servicio.Consulta_Comprobantes_Con_Filtro(lst));
        //}

        // POST api/<ComprobantesController>
        //[HttpPost("GrabarCliente")]
        //public IActionResult PostClienteComprobante(Cliente cliente)
        //{
        //    if (cliente != null)
        //    {
        //        bool result = servicio.InsertarUsuario(cliente);
        //        return Ok(result);
        //    }
        //    return BadRequest("Debe ingresar un cliente!");
        //}

        // PUT api/<ComprobantesController>/5
        //[HttpPut("ModificarCliente")]
        //public IActionResult PutClienteComprobante(Cliente cliente)
        //{
        //    if (cliente != null)
        //    {
        //        bool result = servicio.ModificarUsuario(cliente);
        //        return Ok(result);
        //    }
        //    return BadRequest("Debe ingresar un cliente!");
        //}

        [HttpPost("AgregarComprobante")]
        public IActionResult PostComprobante(List<Parametro2> parametrosTipados)
        {
            if (parametrosTipados != null && parametrosTipados.Count > 0)
            {
                bool result = servicio.AgregarComprobante(parametrosTipados);
                return Ok(result);
            }
            return BadRequest(false);
        }

        [HttpGet("GetTiposDocumento")]
        public IActionResult GetTiposDocumento()
        {
            return Ok(servicio.CargarComboTiposDocumento());
        }

        //// DELETE api/<ComprobantesController>/5
        //[HttpDelete("{id}")]
        //public void DeleteComprobante(int id)
        //{
        //}
    }
}

