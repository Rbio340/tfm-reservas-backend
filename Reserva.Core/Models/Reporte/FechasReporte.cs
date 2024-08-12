using System.ComponentModel;

namespace Reserva.Core.Models.Reporte
{
    public class FechasReporte
    {
        [DisplayName("Fecha Inicio Movimiento")]
        public DateTime fecMovimientoInicio { get; set; } = default!;
        [DisplayName("Fecha Fin Movimiento")]
        public DateTime fecMovimientoFin { get; set; } = default!;
    }
}
