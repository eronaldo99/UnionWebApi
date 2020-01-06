using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cDirector
    {
        public int U_ID { get; set; }
        public string USR_EMAIL { get; set; }
        public string A_ID { get; set; }
        public string USR_NOMBRE { get; set; }
        public string USR_TELEFONO { get; set; }
        public string Imagen { get; set; }

        public cDirector(DataRow pDr)
        {
            this.U_ID = int.Parse(pDr["U_ID"].ToString());
            this.USR_EMAIL = pDr["USR_EMAIL"].ToString();
            this.A_ID = pDr["A_ID"].ToString();
            this.USR_NOMBRE = pDr["USR_NOMBRE"].ToString();
            this.USR_TELEFONO = pDr["USR_TELEFONO"].ToString();
            this.Imagen = cDatos.ArchivoRutaWeb() + pDr["USUARIO_A_ID_MAS_EXTENSION"].ToString();
        }
    }
}