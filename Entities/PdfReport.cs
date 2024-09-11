using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficioPersuasivoPenalizable.Entities
{
    public class PdfReport
    {
        public string expediente;
        public string proceso;
        public Contribuyente contribuyente;
        public List<Declaracion> declaracion;
    }
}
