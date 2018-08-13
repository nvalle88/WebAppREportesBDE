using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppReportesBDE.Utiles;

namespace WebAppReportesBDE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.QueryString.Count > 0)
            {

                var ReporteClientesPath = Request.QueryString[0];

                var parametros = new List<Parametro>();

                for (int i = 1; i < Request.QueryString.AllKeys.Length; i++)
                {
                    parametros.Add(new Parametro { Clave = Request.QueryString.Keys[i], Valor = Request.QueryString[Request.QueryString.Keys[i]] });
                }


                var clienteReporte = new ClienteReporte { Parametros = parametros, ReporteClientesPath = ReporteClientesPath };

                return RedirectToActionPermanent("Report", "Reports", clienteReporte);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "No es posible mostrar la página");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}