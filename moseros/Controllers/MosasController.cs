using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using moseros.services;
using moseros.viewmodels;

namespace moseros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MosasController : ControllerBase
    {
        public IMosa mosa;

        public MosasController(IMosa _mosas)
        {
            this.mosa = _mosas;
        }
        [HttpGet("ObtenerMosa")]
        public ActionResult ObtenerMosas()
        {
            return new JsonResult(mosa.ObtenerMosas());
        }
        [HttpPost("setMosa")]
        public bool setMosas(MosaVM mosas)
        {
            return mosa.setMosas(mosas);
        }
        [HttpPost("putMosa")]
        public bool putMosas(MosaVM mosas)
        {
            return mosa.putMosas(mosas);
        }
        [HttpPost("deleteMosas")]
        public bool deleteMosas(int id)
        {
            return mosa.deleteMosas(id);
        }
    }
}

