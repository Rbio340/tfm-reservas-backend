using System.ComponentModel;

namespace Reserva.Core.Models.Reporte
{
    public class HeaderReporte
    {
        [DisplayName("Proceso Electoral")]
        public string procesoElectoral { get; set; } = default!;
        [DisplayName("Nombre Partido")]
        public string nombrePartido { get; set; } = default!;
        [DisplayName("Dignidad")]
        public string dignidad { get; set; } = default!;
        [DisplayName("Provincia")]
        public string provincia { get; set; } = default!;
        [DisplayName("Cantón")]
        public string? canton { get; set; } = default!;
        [DisplayName("Parroquia")]
        public string? parroquia { get; set; } = default!;
        [DisplayName("Circunscripcion")]
        public string? urlLogo { get; set; } = default!;

        public string? circunscripcion { get; set; } = default!;
        [DisplayName("Logo de la Organización Política")]
        public byte[] logoPartido { get; set; } = default!;
        public string? rucCampania { get; set; } = default!;
    }
}
