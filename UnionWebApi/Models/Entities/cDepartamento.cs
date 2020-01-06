using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cDepartamento
    {
        public int D_ID { get; set; }
        //public int I_ID { get; set; }
        public string DT_PK { get; set; }
        public cDirector U_ID { get; set; }
        public List<cNoticia> Noticias { get; set; }


        public cDepartamento(int pId)
        {
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_DEPARTAMENTO", pId.ToString()))
            {
                if (dt.Rows.Count != 1) return;
                this.D_ID = pId;
                this.DT_PK = dt.Rows[0]["DT_PK"].ToString();
                this.U_ID = new cDirector(dt.Rows[0]);
            }
            this.Noticias = new List<cNoticia>();
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_NOTICIA", this.D_ID))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.Noticias.Add(new cNoticia(dr));
                }
            }
        }
        public cDepartamento(DataRow pDr)
        {
            this.D_ID = int.Parse(pDr["D_ID"].ToString());
            this.DT_PK = pDr["DT_PK"].ToString();
            this.U_ID = new cDirector(pDr);
        }
    }
}