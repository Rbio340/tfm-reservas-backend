
using Reserva.Core.Models.Reporte;
using System.ComponentModel;

public class ParamsReporte
{
    [DisplayName("Fechas del reporte")]
    public FechasReporte? fechas { get; set; } = default!;
    [DisplayName("Encabezado del reporte")]
    public HeaderReporte? header { get; set; } = default!;
    [DisplayName("Data")]
    public object? data { get; set; }
    [DisplayName("Pie de página del reporte")]
    public FooterReporte? footer { get; set; } = default!;
}