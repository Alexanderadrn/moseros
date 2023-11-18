using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moseros.services;

namespace moseros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionController : ControllerBase
    {
        public IRelacion relacion;
        public RelacionController(IRelacion _relacion)
        {
            this.relacion = _relacion;
        }
       /* [HttpGet("ObtenerAmante")]
        public ActionResult ObtenerRelacion()
        {
            return new JsonResult(relacion.ObtenerMosas());
        } */
        [HttpGet("GetAmantesById")]
        public IActionResult GetAmantesById(int id)
        {
            var result = relacion.GetAmantesById(id);
            return new JsonResult(result);
        }
        [HttpGet("GetMosas")]
        public IActionResult GetMosas()
        {
            var result = relacion.GetMosas();
            return new JsonResult(result);
        }
    }
}





