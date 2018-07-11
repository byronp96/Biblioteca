using Lec10.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec10.DAL.Interfaces
{
    public interface IMedicamento
    {
        List<Medicamento> ListarMedicamentos();
        Medicamento BuscarMedicamento(int idMedicamento);
        void InsertarMedicamento(Medicamento medicamento);
        void ActualizarMedicamento(Medicamento medicamento);
        void EliminarMedicamento(int idMedicamento);
    }
}
