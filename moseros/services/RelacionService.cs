using Microsoft.EntityFrameworkCore;
using moseros.Models;
using moseros.viewmodels;

namespace moseros.services
{
    public class RelacionService : IRelacion
    {
        private MoserosContext _context;

        public RelacionService(MoserosContext context)
        {
            this._context = context;
        }
        public List<MosaRelacionVM> GetMosas()
        {

            List < MosaRelacionVM> listMosas = new List<MosaRelacionVM>();

            var mosas= _context.Mosas.ToList();
            foreach (var mosa in mosas)
            {
                
                    MosaRelacionVM registro = new MosaRelacionVM()
                    {
                        idMosaRelacion =mosa.Id,
                        nombreMosaRelacion= mosa.Nombre,
                        

                    };
                listMosas.Add(registro);
                
            }
            return listMosas;
        }

            

            


        /*public MosaVM GetMosas()
        {
            MosaVM mosaVM = null;
            var mosa = _context.Mosas.Where(X => X.Id !=null).FirstOrDefault();

            mosaVM = new MosaVM
            {
                IDMosa = mosa.Id,
                nombreMosa = mosa.Nombre
            };
            return mosaVM; */
        
        public MoserosRelacionVM GetAmantesById(int id)
        {
            MoserosRelacionVM moserosVM  = null;
            var amanteID  = _context.Amantes.Where(X => X.Id == id).FirstOrDefault();


            moserosVM = new MoserosRelacionVM
            {
                IDMoserosRelacion=amanteID.Id, 
                nombreMoserosRelacion=amanteID.Nombre
            };
            return moserosVM;
        }
        
    }
}
