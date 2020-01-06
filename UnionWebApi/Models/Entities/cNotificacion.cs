using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cNotificacion
    {
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string IdDestino { get; set; }
        public DateTime Fecha { get; set; }

        public cNotificacion(DataRow pDr)
        {
            this.Titulo = pDr["TITULO"].ToString();
            this.Mensaje = pDr["MENSAJE"].ToString();
            this.Fecha = DateTime.Parse( pDr["FECHA"].ToString());
            this.Tipo = pDr["TIPO"].ToString();
            this.IdDestino = pDr["ID_DESTINO"].ToString();
        }

        public static List<cNotificacion> Historial(int pIglesiaId)
        {
            List<cNotificacion> notificaciones = new List<cNotificacion>();
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_NOTIFICACIONES", pIglesiaId))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    notificaciones.Add(new cNotificacion(dr));
                }
            }
            return notificaciones;
        }
    }
}