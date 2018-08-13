using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebAppReportesBDE.Utiles;

namespace WebAppReportesBDE.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Report()
        {

            try
            {
                var ReporteClientesPath = Request.QueryString[0];

                var parametros = new List<Parametro>();

                for (int i = 1; i < Request.QueryString.AllKeys.Length; i++)
                {
                    parametros.Add(new Parametro { Clave = Request.QueryString.Keys[i], Valor = Request.QueryString[Request.QueryString.Keys[i]] });
                }

                ReportViewer rptViewer = new ReportViewer();

                // ProcessingMode will be Either Remote or Local  
                rptViewer.ProcessingMode = ProcessingMode.Remote;
                rptViewer.SizeToReportContent = true;
                rptViewer.ZoomMode = ZoomMode.PageWidth;
                rptViewer.Width = Unit.Percentage(100);
                rptViewer.Height = Unit.Percentage(100);
                rptViewer.AsyncRendering = true;

                IReportServerCredentials irsc = new CustomReportCredentials(Constantes.UsuarioReporte, Constantes.ContrasenaReporte);

                rptViewer.ServerReport.ReportServerCredentials = irsc;

                rptViewer.ServerReport.ReportServerUrl = new Uri(Constantes.ServerReportUrl);
                rptViewer.ServerReport.ReportPath = ReporteClientesPath;

                if (parametros.Count > 0)
                {
                    var parameters = AdicionarParaMetros(parametros);
                    rptViewer.ServerReport.SetParameters(parameters);
                };

                rptViewer.ServerReport.Refresh();
                ViewBag.ReportViewer = rptViewer;
                return View();
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "El reporte solicitado no se ha podido mostrar...");
            }
        }

        private List<ReportParameter> AdicionarParaMetros(List<Parametro> parametros)
        {

            var parameters = new List<ReportParameter>();
            foreach (var item in parametros)
            {
                parameters.Add(new ReportParameter(item.Clave.ToString(),item.Valor.ToString()));
                
            }
            return parameters;
           
        }
    }
}