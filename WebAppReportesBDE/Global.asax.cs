using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppReportesBDE.Utiles;

namespace WebAppReportesBDE
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Constantes.ServerReportUrl = System.Configuration.ConfigurationManager.AppSettings["ServerReportUrl"];
            Constantes.UsuarioReporte = System.Configuration.ConfigurationManager.AppSettings["UsuarioReporte"];
            Constantes.ContrasenaReporte = System.Configuration.ConfigurationManager.AppSettings["ContrasenaReporte"];
        }
    }
}
