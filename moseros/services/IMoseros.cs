using moseros.Models;
using moseros.viewmodels;

namespace moseros.services
{
    public interface IMoseros
    {
        public List<MoserosVM> ObtenerMoseros();

        public bool setMosero(MoserosVM moseros);

        public bool putMoseros( MoserosVM moseros);
        public bool deleteMoseros(int id);



    }
}
