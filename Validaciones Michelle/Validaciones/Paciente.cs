using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validaciones
{
    class Paciente
    {
        public string NombrePaciente { get; set; }
        public long nDocumento;
        public TipoDocumento TipoDocumento { get; set; }
        public Rango Rango { get; set; }
        public long costoS { get; set; }

    }
}
