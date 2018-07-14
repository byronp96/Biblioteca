using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Metodos
{
    public class MCliente
    {                   
        public bool InsertarCliente(Cliente cliente)
        {                                        
            StringBuilder consulta = new StringBuilder();
            consulta.Append("INSERT INTO Cliente (cli_codigo,cli_identificacion,cli_nombre,cli_apellido,cli_correo,cli_fecha_nacimiento,cli_telefono,cli_clave) ");
            consulta.Append(cliente.cli_codigo);
            consulta.Append(cliente.cli_identificacion);
            consulta.Append(cliente.cli_nombre);
            consulta.Append(cliente.cli_apellido);
            consulta.Append(cliente.cli_correo);
            consulta.Append(cliente.cli_fecha_nacimiento);
            consulta.Append(cliente.cli_telefono);
            consulta.Append(cliente.cli_clave);
            consulta.Append("Values (");
            consulta.Append(")");

            using (IDbConnection db = new SqlConnection(BD.Default.conexion))
            {                                         
                int vlnRegistrosAfectados = db.Execute(consulta.ToString());

                if (vlnRegistrosAfectados >= 1) return true;
                else return false;
            }    
        }
    }
}
