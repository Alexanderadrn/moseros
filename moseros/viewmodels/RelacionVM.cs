using moseros.Models;

namespace moseros.viewmodels
{
    public class RelacionVM

    {
        public int idRelacion { get; set; }

        public int? idRelacionAmamte { get; set; }

        public int? idRelacionMosa { get; set; }

        public virtual Amante? IdAmamteNavigation { get; set; }

        public virtual Mosa? IdMosaNavigation { get; set; }

    }
}
