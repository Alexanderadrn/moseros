using moseros.Models;
using moseros.viewmodels;
using System.Text.RegularExpressions;

namespace moseros.services
{
    public class MoserosService : IMoseros
    {
        private MoserosContext _context;

        public MoserosService(MoserosContext context)
        {
            this._context = context;
        }
        public List<MoserosVM> ObtenerMoseros()
        {
            List<MoserosVM> listMoseros = new List<MoserosVM>();
            var moseros = _context.Amantes.ToList();
            foreach (var mosero in moseros)
            {
                MoserosVM registro = new MoserosVM
                 {
                    ID=mosero.Id,
                   nombre=mosero.Nombre,
                   edad=mosero.Edad,
                   algo=mosero.Algo,
                   direccion=mosero.Direccion,
                    
                    
                 };
                listMoseros.Add(registro);


            }
            return listMoseros;
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
        public bool putMoseros(MoserosVM moseros)
        {
            bool registrado = false;
            try
            {
                // Amante amanteBD = new Amante(); aqui tambien la cague, no es linea de conexion
                var putMoseros = _context.Amantes.Where(X => X.Id == moseros.ID).FirstOrDefault();
                putMoseros.Nombre = moseros.nombre;
                putMoseros.Edad = moseros.edad;
                putMoseros.Algo = moseros.algo;
                putMoseros.Direccion = moseros.direccion;
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
        public bool deleteMoseros(int id)
        {
            bool registrado = false;
            var deleteMoseros = _context.Amantes.Where(X => X.Id == id).FirstOrDefault();
            try
            {
                // Amante amanteBD = new Amante(); no es linea de conexion

                // if (deleteMoseros == null) { throw new Exception("el usario no existe"); }
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
