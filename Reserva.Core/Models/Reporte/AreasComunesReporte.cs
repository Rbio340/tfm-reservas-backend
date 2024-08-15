using Reserva.Core.Dto;

namespace Reserva.Core.Models.Reporte
{
    public class AreasComunesReporte
    {
        public AreasComunesReporte(List<AreaComunDto> data)
        {
            this.data = data;
        }
        public List<AreaComunDto> data { get; set; }
    }
}
