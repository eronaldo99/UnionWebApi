using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cDirigente
    {
        public int U_ID { get; set; }
        public string USR_EMAIL { get; set; }
        public string A_ID { get; set; }
        public string USR_NOMBRE { get; set; }
        public string USR_TELEFONO { get; set; }
        public string Imagen { get; set; }
        public string Cargo { get; set; }


        public cDirigente(DataRow pDr)
        {
            this.U_ID = int.Parse(pDr["U_ID"].ToString());
            this.USR_EMAIL = pDr["USR_EMAIL"].ToString();
            this.A_ID = pDr["A_ID"].ToString();
            this.USR_NOMBRE = pDr["USR_NOMBRE"].ToString();
            this.USR_TELEFONO = pDr["USR_TELEFONO"].ToString();
            this.Imagen = cDatos.ArchivoRutaWeb() + pDr["A_ID_MAS_EXTENSION"].ToString();
            this.Cargo = (pDr["P_PK"].ToString()=="ADMINISTRADOR" || pDr["P_PK"].ToString()=="DIRECTOR")? pDr["DT_PK"].ToString(): Funciones.PrimeraLetraMayuscula( pDr["P_PK"].ToString());
        }
        public static List<cDirigente> Todos(int pIglesiaId)
        {
            List<cDirigente> dirigentes = new List<cDirigente>();
            using (DataTable dt= Funciones.ExecuteDataTable("PA_API_DIRIGENTES",pIglesiaId))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dirigentes.Add(new cDirigente(dr));
                }
            }
            return dirigentes;
        }
    }
}