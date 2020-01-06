using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities.Seccion
{
    public class ItemPrincipal
    {
        public int IP_ID { get; set; }
        public int I_ID { get; set; }
        public string IP_TITULO { get; set; }
        public string IP_DESCRIPCION { get; set; }
        public string IP_IMAGEN_URL { get; set; }
        public string IP_URL { get; set; }
        public DateTime IP_FECHA_SISTEMA { get; set; }

        public static ItemPrincipal Principal(int pIglesiaId)
        {
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_ITEM_PRINCIPAL", pIglesiaId))
            {
                if (dt.Rows.Count == 1)
                {
                    return new ItemPrincipal()
                    {
                        IP_TITULO = dt.Rows[0]["IP_TITULO"].ToString(),
                        IP_DESCRIPCION = dt.Rows[0]["IP_DESCRIPCION"].ToString(),
                        IP_URL = dt.Rows[0]["IP_URL"].ToString(),
                        IP_ID = int.Parse(dt.Rows[0]["IP_ID"].ToString()),
                        IP_IMAGEN_URL= dt.Rows[0]["IP_IMAGEN_URL"].ToString()
                    };
                }
                else
                    return null;
            }
        }
    }
    }