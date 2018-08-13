using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReportesBDE.Utiles
{
    public class ClienteReporte
    {
        public string ReporteClientesPath { get; set; }
        public List<Parametro> Parametros { get; set; }
    }
}