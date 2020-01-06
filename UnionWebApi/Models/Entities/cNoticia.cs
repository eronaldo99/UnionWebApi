using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cNoticia
    {
        public int N_ID { get; set; }
        public string A_ID { get; set; }
        public string N_TITULO { get; set; }
        public DateTime N_FECHA { get; set; }
        public DateTime N_FECHA_SISTEMA { get; set; }
        public string Imagen { get; set; }
        //public string DT_PK { get; set; }
        //public cDirector U_ID { get; set; }

        public static cNoticia getNoticia(int pId)
        {
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_NOTICIA_GET", pId.ToString()))
            {
                if (dt.Rows.Count != 1) return null;
                return new cNoticia(dt.Rows[0]);
            }
        }

        public cNoticia(DataRow pDr)
        {
            this.N_ID = int.Parse(pDr["N_ID"].ToString());
            this.A_ID = pDr["A_ID"].ToString();
            this.N_TITULO = pDr["N_TITULO"].ToString();
            this.N_FECHA = DateTime.Parse(pDr["N_FECHA"].ToString());
            this.N_FECHA_SISTEMA = DateTime.Parse(pDr["N_FECHA_SISTEMA"].ToString());
            this.Imagen=cDatos.ArchivoRutaWeb() + pDr["A_ID_MAS_EXTENSION"].ToString();
            //this.DT_PK = pDr["DT_PK"].ToString();
            //this.U_ID = pDirector;
        }
        public cNoticia()
        { }

    }
}