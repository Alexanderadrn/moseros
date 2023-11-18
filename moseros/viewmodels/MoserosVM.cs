using System.Security.Principal;

namespace moseros.viewmodels
{
    public class MoserosVM
    {
        public int ID { get; set; }
        public string? nombre { get; set; }
        public decimal? edad { get; set; }

        public string? algo { get; set; }
        

        public string? direccion { get; set; }


    }
    public class MoserosRelacionVM
    {
        public int IDMoserosRelacion { get; set; }
        public string nombreMoserosRelacion { get; set; }

    }
}
