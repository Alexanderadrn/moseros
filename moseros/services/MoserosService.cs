using moseros.Models;
using moseros.viewmodels;

namespace moseros.services
{
    public class MoserosService : IMoseros
    {
        private MoserosContext _context;

        public MoserosService(MoserosContext context)
        {
            this._context = context;
        }
        public List<Amante> ObtenerMoseros()
        {
            var moseros = _context.Amantes.ToList();

            return moseros;

        }
        public bool setMosero(MoserosVM moseros)
        {
            bool registrado = false;

            try
            {
                Amante amanteBD = new Amante();
                amanteBD.Nombre = moseros.nombre;
                amanteBD.Edad = moseros.edad;
                amanteBD.Algo = moseros.algo;
                amanteBD.Direccion = moseros.direccion;
                _context.Amantes.Add(amanteBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
                return registrado;
        }
      public bool putMoseros (int id, MoserosVM moseros)
        {
            bool registrado = false;
            try
            {
               // Amante amanteBD = new Amante(); aqui tambien la cague, no es linea de conexion
                var putMoseros = _context.Amantes.Where(X => X.Id == id).FirstOrDefault();
                putMoseros.Nombre = moseros.nombre;
                putMoseros.Edad=moseros.edad;
                putMoseros.Algo=moseros.algo;
                putMoseros.Direccion=moseros.direccion;
               // _context.Amantes.Update(amanteBD); aqui la cague
                _context.SaveChanges();
                registrado = true;

            }
            catch
            {
                registrado = false;

            }
            return registrado;
        }
        public bool deleteMoseros (int id)
        {
            bool registrado = false;
            try
            {
               // Amante amanteBD = new Amante(); no es linea de conexion
                var deleteMoseros = _context.Amantes.Where(X => X.Id == id).FirstOrDefault();
                if (deleteMoseros == null) { throw new Exception("el usario no existe"); }
                _context.Amantes.Remove(deleteMoseros);
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;

           
        }
        
           
        
        
    }
}
