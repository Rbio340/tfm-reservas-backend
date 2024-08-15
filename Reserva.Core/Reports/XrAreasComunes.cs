using DevExpress.DataAccess.Json;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using Reserva.Core.Dto;
using Reserva.Core.Models.Reporte;
using Reserva.Core.Models;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Reserva.Core.Reports
{
    public partial class XrAreasComunes : DevExpress.XtraReports.UI.XtraReport
    {
        public XrAreasComunes()
        {
            InitializeComponent();
        }
        public XrAreasComunes(List<AreaComunDto> areasComunes)
        {
            var areasReporte = new AreasComunesReporte(areasComunes);

            InitializeComponent();
            // Configurar la serialización para evitar referencias circulares
            string jsonData = JsonConvert.SerializeObject(areasReporte, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            jsonDataSource1.JsonSource = new CustomJsonSource(jsonData);
            jsonDataSource1.Fill();
        }
    }
}
