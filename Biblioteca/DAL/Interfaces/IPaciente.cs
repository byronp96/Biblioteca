using Lec10.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec10.DAL.Interfaces
{
    public interface IPaciente
    {
        List<Paciente> ListarPacientes();
        Paciente BuscarPaciente(int idPaciente);
        void InsertarPaciente(Paciente paciente);
        void ActualizarPaciente(Paciente paciente);
        void EliminarPaciente(int idPaciente);
        string CambioContraseña(Contrasena contrasena);
    }
}
