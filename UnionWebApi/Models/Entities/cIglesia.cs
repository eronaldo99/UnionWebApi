using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cIglesia
    {
        public int I_ID { get; set; }
        public string I_NOMBRE { get; set; }

        public List<cDirigente> Dirigentes { get; set; }

        //public cIglesia(int pId)
        //{
        //    this.I_ID = pId;
        //    this.I_NOMBRE = "Iglesia Central";
        //    List<cDirigente> aux = new List<cDirigente>();
        //    using (DataTable dt = Funciones.ExecuteDataTable("PA_API_DIRIGENTES", 1))
        //    {
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                aux.Add(new cDirigente(dr));
        //            }
        //        }
        //    }
        //    this.Dirigentes = aux;
        //}
    }
}