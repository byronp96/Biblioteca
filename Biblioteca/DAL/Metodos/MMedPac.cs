using Lec10.DAL.Interfaces;
using Lec10.DATA;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec10.DAL.Metodos
{
    public class MMedPac : IMedPac
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;

        public MMedPac()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.conexion,
                SqlServerDialect.Provider);
            _db = _conexion.Open();
        }

        public void ActualizarMP(MedicamentoPaciente medPac)
        {
            _db.Update(medPac);
        }

        public MedicamentoPaciente BuscarMP(int idPaciente, int idMedicamento)
        {
            return _db.Select<MedicamentoPaciente>(x => x.IdPaciente == idPaciente && x.IdMedicamento == idMedicamento).FirstOrDefault();
        }

        public void EliminarMP(int idPaciente, int idMedicamento)
        {
            _db.Delete<MedicamentoPaciente>(x => x.IdPaciente == idPaciente && x.IdMedicamento == idMedicamento);
        }

        public void InsertarMP(MedicamentoPaciente medPac)
        {
            try
            {
                _db.Insert(medPac);
            }
            catch (Exception)
            {
                ActualizarMP(medPac);
            }
            
        }

        public List<MedicamentoPaciente> ListarMP()
        {
            return _db.Select<MedicamentoPaciente>();
        }

        //public void EjemploEjecutarStoredProcedure(int idPaciente, string contra)
        //{
        //    _db.ExecuteSql(string.Format("EXEC sp_nombreStoredProcedure {0},{1}", id, contra));
        //}
    }
}
