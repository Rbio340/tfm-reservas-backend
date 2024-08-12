﻿using DevExpress.DataAccess.Json;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using Reserva.Core.Models;
using Reserva.Core.Models.Reporte;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Reserva.Core.Reports
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            //InitializeComponent();
        }

        public XtraReport1(List<Reservas> reservas)
        {
            var reservaReporte = new ReservaReporte(reservas);

            InitializeComponent();
            // Configurar la serialización para evitar referencias circulares
            string jsonData = JsonConvert.SerializeObject(reservaReporte, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            jsonDataSource1.JsonSource = new CustomJsonSource(jsonData);
            jsonDataSource1.Fill();
        }
    }
}
