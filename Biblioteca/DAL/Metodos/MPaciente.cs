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
    public class MPaciente : IPaciente
    {
        private OrmLiteConnectionFactory _conexion;
        private IDbConnection _db;

        public MPaciente()
        {
            _conexion = new OrmLiteConnectionFactory(BD.Default.conexion,
                SqlServerDialect.Provider);
            _db = _conexion.Open();
        }



        public void ActualizarPaciente(Paciente paciente)
        {
            try
            {
                _db.Update(paciente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Paciente BuscarPaciente(int idPaciente)
        {
            try
            {
                return _db.Select<Paciente>(x => x.IdPaciente == idPaciente).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void EliminarPaciente(int idPaciente)
        {
            try
            {
                _db.Delete<Paciente>(x => x.IdPaciente == idPaciente);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void InsertarPaciente(Paciente paciente)
        {
            try
            {
                _db.Insert(paciente);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Paciente> ListarPacientes()
        {
            try
            {
                return _db.Select<Paciente>();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public string CambioContraseña(Contrasena contrasena)
        {
            string mensaje = "";
            try
            {
                if (_db.Select<Paciente>().Where(x => x.IdPaciente == contrasena.idPaciente && x.Contraseña == contrasena.ContraseñaVieja).Count() >= 1)
                {
                    if (contrasena.ContraseñaNueva == contrasena.ContraseñaNuevaConfirmacion)
                    {
                        _db.ExecuteSql(string.Format("EXEC sp_CambioContrasena {0},{1}", contrasena.idPaciente, contrasena.ContraseñaNueva));
                        mensaje = "Actualizado Correctamente";
                    }
                    else
                    {
                        mensaje = "La nueva contraseñas no coincide con su confirmación";
                    }
                }
                else
                {
                    mensaje = "Verifique si existe a la contraseña o el paciente";
                }
                return mensaje;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
