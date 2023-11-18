using moseros.Models;
using moseros.viewmodels;

namespace moseros.services
{
    public interface IMosa
    {
        public List<MosaVM> ObtenerMosas();
        public bool setMosas(MosaVM mosas);
        public bool putMosas(MosaVM mosas);
        public bool deleteMosas(int id);

    }
}
