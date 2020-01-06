using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cUsuario
    {
        public string C_PK { get; set; }
        public string C_NOMBRE { get; set; }
        public string C_APELLIDO { get; set; }
        public string C_NOMBRE_COMPLETO { get; set; }
        public string C_FACEBOOK_TOKEN { get; set; }
        public string C_IMAGEN { get; set; }
        public string FirebaseToken { get; set; }
        public int I_Id { get; set; } //iglesia despues de crear usuario, debe seleccionar iglesia y deptos.

        public void Guardar()
        {
            Funciones.ExecuteSql("PA_API_CLIENTE_insert",this.C_PK,this.C_NOMBRE,this.C_APELLIDO,this.C_NOMBRE_COMPLETO,this.C_FACEBOOK_TOKEN,this.C_IMAGEN,this.FirebaseToken);
        }
        public void AsignarIglesia()
        {
            Funciones.ExecuteSql("PA_API_USUARIO_IGLESIA_ASIGNAR",this.I_Id, this.C_PK);
        }
    }
}