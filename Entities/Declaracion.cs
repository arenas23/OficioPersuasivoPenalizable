namespace OficioPersuasivoPenalizable.Entities
{
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
