using moseros.Models;
using moseros.viewmodels;

namespace moseros.services
{
    public class MosaService : IMosa
    {
        private MoserosContext _context;

        public MosaService(MoserosContext context)
        {
            this._context = context;

        }
        public List<MosaVM> ObtenerMosas()
        {
            List<MosaVM> listMosas = new List<MosaVM>();
            var mosas = _context.Mosas.ToList();
            foreach (var mosa in mosas)
            {
                MosaVM registro = new MosaVM
                {
                    IDMosa = mosa.Id,
                    nombreMosa = mosa.Nombre,
                    edadMosa = mosa.Edad,
                    algoMosa = mosa.Algo,
                    direccionMosa = mosa.Direccion,


                };
                listMosas.Add(registro);


            }
            return listMosas;

        }
        public bool setMosas(MosaVM mosas)
        {
            bool registrado = false;

            try
            {
                Mosa mosasBD = new Mosa();
                mosasBD.Nombre = mosas.nombreMosa;
                mosasBD.Edad = mosas.edadMosa;
                mosasBD.Algo = mosas.algoMosa;
                mosasBD.Direccion = mosas.direccionMosa;

                _context.Mosas.Add(mosasBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }

        public bool putMosas(MosaVM mosas)
        {
            bool registrado = false;
            try
            {
                var putMosas = _context.Mosas.Where(X => X.Id == mosas.IDMosa).FirstOrDefault();
                putMosas.Nombre = mosas.nombreMosa;
                putMosas.Edad = mosas.edadMosa;
                putMosas.Algo = mosas.algoMosa;
                putMosas.Direccion = mosas.direccionMosa;
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }
        public bool deleteMosas(int id)
        {
            bool registrado = false;
            var deleteMosas = _context.Mosas.Where(X => X.Id == id).FirstOrDefault();
            try
            {
                _context.Mosas.Remove(deleteMosas);
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
