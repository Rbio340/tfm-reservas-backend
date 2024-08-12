using System.ComponentModel;

public class FooterReporte
{
    [DisplayName("Cédula del Contador Público Autorizado")]
    public string? cedulaCPA { get; set; } = default!;
    [DisplayName("Cédula del Contador Público Autorizado")]
    public string? nombreCPA { get; set; } = default!;
    [DisplayName("Cédula de Responsable de Manejo Económico")]
    public string? cedulaRME { get; set; } = default!;
    [DisplayName("Nombre de Responsable de Manejo Económico")]
    public string? nombreRME { get; set; } = default!;
    [DisplayName("Cédula del Jefe de Campaña")]
    public string? cedulaJC { get; set; } = default!;
    [DisplayName("Nombre del Jefe de Campaña")]
    public string? nombreJC { get; set; } = default!;
    [DisplayName("Codigo de Impresión QR")]
    public string? COD_IMPRESION { get; set; }
    [DisplayName("Cédula del Custodio")]
    public string? cedulaCustodio { get; set; } = default!;
    [DisplayName("Nombre del Custodio")]
    public string? nombreCustodio { get; set; } = default!;
    public string? fechaCierre { get; set; } = default!;
}