namespace Reserva.Core.Models.Reporte
{
    public class ReservaReporte
    {
        public ReservaReporte(List<Reservas> data)
        {
            this.data = data;
        }

        public List<Reservas> data { get; set; }
    }
}
