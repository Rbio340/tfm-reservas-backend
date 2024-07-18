namespace Reserva.Core.Models
{
    public class Configuracion
    {
        public int? ConfigId { get; set; }
        public int EspId { get; set; }
        public DateTime FecMinReserva { get; set; }
        public DateTime FecMaxReserva { get; set; }
        public TimeSpan TiempMinReserva { get; set; }
        public TimeSpan TiempMaxReserva { get; set; }
        public int NumMinPersona { get; set; }
        public int NumMaxPersona { get; set; }
    }
}