using moseros.Models;
using moseros.viewmodels;

namespace moseros.services
{
    public interface IRelacion
    {
        //public List<Mosa> ObtenerMosas();
        public MoserosRelacionVM GetAmantesById(int id);
        public List<MosaRelacionVM> GetMosas();
    }
}
