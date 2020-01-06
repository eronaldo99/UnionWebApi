using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cParametro
    {
        public static string getValue(string pPk)
        {
            object value= Funciones.ExecuteScalar("EXEC PA_PARAMETRO_OBTENER '"+pPk+"'");
            if (value == null) return string.Empty;
            return value.ToString();
            
        }
    }
}