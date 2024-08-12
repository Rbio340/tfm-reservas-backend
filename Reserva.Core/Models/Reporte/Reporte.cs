
using System.ComponentModel;

public class Reporte
{
    [DisplayName("Nombre del reporte cs")]
    public string nameReport { get; set; } = default!;
    [DisplayName("Parametros de reporte header y data")]
    public ParamsReporte paramsReport { get; set; } = default!;

}