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
    public class MMedicamento : IMedicamento
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;

        public MMedicamento()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.conexion,
                SqlServerDialect.Provider);
            _db = _conexion.Open();
        }

        public void ActualizarMedicamento(Medicamento  Medicamento)
        {
            _db.Update( Medicamento);
        }

        public Medicamento BuscarMedicamento(int idMedicamento)
        {
            return _db.Select<Medicamento>(x => x.IdMedicamento == idMedicamento).FirstOrDefault();
        }

        public void EliminarMedicamento(int idMedicamento)
        {
            _db.Delete<Medicamento>(x => x.IdMedicamento == idMedicamento);
        }

        public void InsertarMedicamento(Medicamento  Medicamento)
        {
            _db.Insert( Medicamento);
        }

        public List<Medicamento> ListarMedicamentos()
        {
            return _db.Select<Medicamento>();
        }

        //public void EjemploEjecutarStoredProcedure(int id Medicamento, string contra)
        //{
        //    _db.ExecuteSql(string.Format("EXEC sp_nombreStoredProcedure {0},{1}", id, contra));
        //}
    }
}
