
using DevExpress.XtraPrinting.Drawing;
using Newtonsoft.Json;
using System.Diagnostics;
using DevExpress.DataAccess.Native.Web;
using static DevExpress.Xpo.Logger.LogManager;
using System.Drawing;
using DevExpress.Drawing;
using Reserva.Core.Models.Reporte;
using Reserva.Core.Reports;
using DevExpress.XtraReports.UI;
using Reserva.Core.Interfaces.Repository.MySql;
using Reserva.Core.Models;
using Reserva.Core.Dto;

namespace Cne.SCFRBackend.Services.Api.Services
{

    public class CustomReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        const string FileExtension = ".cs";
        readonly string ReportDirectory;
        private readonly IReservaRepository _reservaRepository;
        private readonly IAreaComunRepository _areaComunRepository;

        public static byte[] GlobalImage { get; set; }


        public CustomReportStorageWebExtension(IReservaRepository reservaRepository,
            IAreaComunRepository areaComunRepository
            //IWebHostEnvironment env
            )
        {
            _reservaRepository = reservaRepository;
            _areaComunRepository = areaComunRepository;
        }

        /*public CustomReportStorageWebExtension()
        {
        }*/

        public override bool CanSetData(string url)
        {
            // Determines whether or not it is possible to store a report by a given URL. 
            // For instance, make the CanSetData method return false for reports that should be read-only in your storage. 
            // This method is called only for valid URLs (i.e., if the IsValidUrl method returned true) before the SetData method is called.

            return true;
        }

        public override bool IsValidUrl(string url)
        {
            // Determines whether or not the URL passed to the current Report Storage is valid. 
            // For instance, implement your own logic to prohibit URLs that contain white spaces or some other special characters. 
            // This method is called before the CanSetData and GetData methods.

            return Path.GetFileName(url) == url;
        }

        public override byte[] GetData(string url)
        {
            // Returns report layout data stored in a Report Storage using the specified URL. 
            // This method is called only for valid URLs after the IsValidUrl method is called.
            try
            {

                Reporte repJsonP = JsonConvert.DeserializeObject<Reporte>(url)!;
                Debug.WriteLine(repJsonP);
                using (MemoryStream ms = new MemoryStream())
                {
                    Func<XtraReport> report = default!;

                    switch (repJsonP.nameReport)
                    {
                        //case "XrCiudadano":

                        //    CiudadanoByIdQuery ci = JsonConvert.DeserializeObject<CiudadanoByIdQuery>(repJsonP.paramsReport.data.ToString());
                        //    var responseCiudadano = this._appService.GetById(Task.FromResult(ci));
                        //    CiudadanoViewModel resCiudadano = responseCiudadano.Result.FirstOrDefault() as CiudadanoViewModel;
                        //    report = () => new XrCiudadano(resCiudadano);
                        //    report().SaveLayoutToXml(ms);
                        //    break;
                        case "XrReservas":
                            //CrcaByCodQuery requestCrca = JsonConvert.DeserializeObject<CrcaByCodQuery>(repJsonP.paramsReport.data!.ToString()!)!;
                            List<Reservas> dataReservas = this._reservaRepository.GetReserva();
                            /*HeaderReporte headerCrca = repJsonP.paramsReport.header!;
                            FooterReporte footerCrca = repJsonP.paramsReport!.footer!;
                            var dataReport = new ReportCrcaViewModel(headerCrca, dataCrca, footerCrca);*/
                            report = () => new XrReservas(dataReservas);
                            report().SaveLayoutToXml(ms);
                            break;
                        case "XrAreasComunes":
                            //CrcaByCodQuery requestCrca = JsonConvert.DeserializeObject<CrcaByCodQuery>(repJsonP.paramsReport.data!.ToString()!)!;
                            List<AreaComunDto> dataAreas = this._areaComunRepository.GetAreasComun();
                            /*HeaderReporte headerCrca = repJsonP.paramsReport.header!;
                            FooterReporte footerCrca = repJsonP.paramsReport!.footer!;
                            var dataReport = new ReportCrcaViewModel(headerCrca, dataCrca, footerCrca);*/
                            report = () => new XrAreasComunes(dataAreas);
                            report().SaveLayoutToXml(ms);
                            break;
                    }
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {

                throw new DevExpress.XtraReports.Web.ClientControls.FaultException("Could not get report data.", ex);
            }
            throw new DevExpress.XtraReports.Web.ClientControls.FaultException(string.Format("Could not find report '{0}'.", url));
        }
        private XtraReport PrintBackground(XtraReport report, String text)
        {
            report.Watermark.Text = text;
            report.Watermark.TextDirection = DirectionMode.ForwardDiagonal;
            report.Watermark.Font = new DXFont("Segoe UI Semibold", 120);
            report.Watermark.ForeColor = ColorTranslator.FromHtml("#6C6C6B");
            report.Watermark.TextTransparency = 150;
            return report;
        }
        static byte[] GuardarInformeEnBytes(XtraReport report)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Exportar el informe al MemoryStream en formato PDF
                report.ExportToPdf(memoryStream);

                // Obtener los bytes del MemoryStream
                byte[] pdfBytes = memoryStream.ToArray();

                Console.WriteLine("Informe guardado en un arreglo de bytes.");

                return pdfBytes;
            }
        }


        public override Dictionary<string, string> GetUrls()
        {
            // Returns a dictionary of the existing report URLs and display names. 
            // This method is called when running the Report Designer, 
            // before the Open Report and Save Report dialogs are shown and after a new report is saved to a storage.

            return Directory.GetFiles(ReportDirectory, "*" + FileExtension)
                                     .Select(Path.GetFileNameWithoutExtension)
                                     //.Union(ReportsFactory.Reports.Select(x => x.Key))
                                     .ToDictionary<string, string>(x => x);
        }

        public override void SetData(XtraReport report, string url)
        {
            // Stores the specified report to a Report Storage using the specified URL. 
            // This method is called only after the IsValidUrl and CanSetData methods are called.

            var resolvedUrl = Path.GetFullPath(Path.Combine(ReportDirectory, url + FileExtension));
            if (!resolvedUrl.StartsWith(ReportDirectory + Path.DirectorySeparatorChar))
            {
                throw new DevExpress.XtraReports.Web.ClientControls.FaultException("Invalid report name.");
            }

            report.SaveLayoutToXml(resolvedUrl);
        }

        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            // Stores the specified report using a new URL. 
            // The IsValidUrl and CanSetData methods are never called before this method. 
            // You can validate and correct the specified URL directly in the SetNewData method implementation 
            // and return the resulting URL used to save a report in your storage.
            SetData(report, defaultUrl);
            return defaultUrl;
        }
    }
}
