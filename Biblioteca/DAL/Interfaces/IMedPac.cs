using Lec10.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec10.DAL.Interfaces
{
    public interface IMedPac
    {
        List<MedicamentoPaciente> ListarMP();
        MedicamentoPaciente BuscarMP(int idPaciente, int idMedicamento);
        void InsertarMP(MedicamentoPaciente medPac);
        void ActualizarMP(MedicamentoPaciente medPac);
        void EliminarMP(int idPaciente, int idMedicamento);
    }
}
