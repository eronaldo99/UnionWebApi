using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cTransmisionEnVivo
    {
        public int TEV_ID { get; set; }
        public string TEV_TITULO { get; set; }
        public string TEV_DESCRIPCION { get; set; }
        public string TEV_URL { get; set; }
        public string TEV_URL_MINI { get; set; }
        public DateTime TEV_FECHA { get; set; }
        public DateTime TEV_FECHA_SISTEMA { get; set; }

        public static cTransmisionEnVivo TransmisionActual(int pIglesiaId)
        {
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_TRANSMISION_EN_VIVO_ACTUAL", pIglesiaId))
            {
                if (dt.Rows.Count != 1) return null;
                return new cTransmisionEnVivo()
                {
                    TEV_DESCRIPCION = dt.Rows[0]["TEV_DESCRIPCION"].ToString(),
                    TEV_FECHA_SISTEMA = DateTime.Parse( dt.Rows[0]["TEV_FECHA_SISTEMA"].ToString()),
                    TEV_FECHA = DateTime.Parse(dt.Rows[0]["TEV_FECHA"].ToString()),
                    TEV_ID = int.Parse( dt.Rows[0]["TEV_ID"].ToString()),
                    TEV_TITULO = dt.Rows[0]["TEV_TITULO"].ToString().Replace("\"", "'"),
                    TEV_URL = dt.Rows[0]["TEV_URL"].ToString()
                };
            }
        }
        public static cTransmisionEnVivo PorId(int pTransmisionId)
        {
            using (DataTable dt = Funciones.ExecuteDataTable("SELECT TEV_ID,TEV_TITULO,TEV_DESCRIPCION,TEV_URL,TEV_FECHA FROM TRANSMISION_EN_VIVO WHERE TEV_ID=" + pTransmisionId))
            {
                if (dt.Rows.Count != 1) return null;
                return new cTransmisionEnVivo()
                {
                    TEV_DESCRIPCION = dt.Rows[0]["TEV_DESCRIPCION"].ToString(),
                    TEV_FECHA = DateTime.Parse(dt.Rows[0]["TEV_FECHA"].ToString()),
                    TEV_ID = int.Parse(dt.Rows[0]["TEV_ID"].ToString()),
                    TEV_TITULO = dt.Rows[0]["TEV_TITULO"].ToString().Replace("\"", "'"),
                    TEV_URL = dt.Rows[0]["TEV_URL"].ToString()
                };
            }
        }
        public static List<cTransmisionEnVivo> Todas(int pIglesiaId)
        {
            List<cTransmisionEnVivo> aux = new List<cTransmisionEnVivo>();
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_TRANSMISION_EN_VIVO_TODAS", pIglesiaId))
            {
                if (dt.Rows.Count < 1) return null;
                foreach (DataRow dr in dt.Rows)
                {
                    aux.Add(new cTransmisionEnVivo()
                    {
                        TEV_DESCRIPCION = dr["TEV_DESCRIPCION"].ToString(),
                        TEV_FECHA_SISTEMA = DateTime.Parse(dr["TEV_FECHA_SISTEMA"].ToString()),
                        TEV_FECHA = DateTime.Parse(dr["TEV_FECHA"].ToString()),
                        TEV_ID = int.Parse(dr["TEV_ID"].ToString()),
                        TEV_TITULO = dr["TEV_TITULO"].ToString().Replace("\"", "'"),
                        TEV_URL = dr["TEV_URL"].ToString(),
                        TEV_URL_MINI = dr["TEV_URL_MINI"].ToString()
                    }
                    );
                }
            }
            return aux;
        }
    }
}