using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models
{
    public class cDatos
    {
        public static string ArchivoRutaWeb()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ArchivoRutaWeb"];
        }
    }
}