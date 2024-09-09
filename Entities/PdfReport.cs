using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficioPersuasivoPenalizable.Entities
{
    public class PdfReport
    {
       
        public Declaracion declaracion;
        public string total;
    }

    public class Declaracion
    {
        public enum Conceptos
        {
            VENTAS,
            RETENCION,
            CONSUMO
        }

        public string? numero;
        public string? tipo;
        public string? fecha;
        public string? concepto;
        public string? anio;
        public string? periodo;
        public string? impuesto;
        public string? sancion;
    }
}
