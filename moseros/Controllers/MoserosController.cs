using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moseros.services;
using moseros.viewmodels;

namespace moseros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoserosController : ControllerBase
    {
        public IMoseros mosero;

        public MoserosController( IMoseros _moseros)
        {
            this.mosero = _moseros;
        }
        [HttpGet("ObtenerMoseros")]
        public string ObtenerMoseros(string nombre)
        {
            return mosero.ObtenerMoseros() +" " + nombre;
        }
        [HttpGet("ObtenerMoseros2")]
        public ActionResult ObtenerMoseros2()
        {
            return new JsonResult( mosero.ObtenerMoseros()) ;
        }
        [HttpPost("setMosero")]
        public bool setMosero(MoserosVM moseros)
        {
            return mosero.setMosero(moseros);
        }
        [HttpPut("putMosero")]
        public bool putMosero(int  id, MoserosVM moseros)
        {
            return mosero.putMoseros(id, moseros);
        }
        [HttpDelete("deleteMosero")]
        public bool deleteMoseros(int id)
        {
            return mosero.deleteMoseros(id);
        }
    }
}
