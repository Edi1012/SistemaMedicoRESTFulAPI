using SistemaMedico.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMedico.Core
{

    /// <summary>
    /// Aqui van las reglas de negocio
    /// </summary>
    public class PacienteService
    {
        private readonly IPacienteRepository pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            this.pacienteRepository = pacienteRepository;
        }
    }
}
