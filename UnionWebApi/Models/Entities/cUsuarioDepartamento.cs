using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cUsuarioDepartamento
    {
        public long UD_ID { get; set; }
        public string C_PK { get; set; }
        public int D_ID { get; set; }
        public void Suscribirse()
        {
           this.UD_ID= Funciones.ExecuteSqlIdentity("PA_API_CLIENTE_DEPARTAMENTO_insert", this.C_PK, this.D_ID,this.UD_ID);
        }
        public static void Desuscribirse(string pUserId, long pDeptoId)
        {
            Funciones.ExecuteSql("PA_API_CLIENTE_DEPARTAMENTO_delete", pUserId, pDeptoId);
        }
        public static bool EstaSuscrito(string pUserId, long pDeptoId)
        {
            return Funciones.ExecuteExisteEnBD("SELECT top 1 1 FROM CLIENTE_DEPARTAMENTO where C_PK='" + pUserId + "' and D_ID=" + pDeptoId.ToString());
        }
    }
}