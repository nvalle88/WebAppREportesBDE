using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppReportesBDE.Utiles
{
    public static class ApiDesencriptar
    {
        public static string Desencriptar(string cadenaDesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadenaDesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}