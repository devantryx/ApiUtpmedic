using ApiUtpmedic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtpmedic.Repository.IRepository
{
    public interface IPacienteRepository
    {
        //Metodos que se utilizaran sobre la tabla Paciente

       
        bool ExistePaciente(int idpaciente);
        IEnumerable<Paciente> GetPacientePersona();
        IEnumerable<Paciente> GetPacienteUsuario();
    }
}
