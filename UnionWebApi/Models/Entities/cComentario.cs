using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cComentario
    {
        public int NCId { get; set; }
        public string Nombre { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
        public string Imagen { get; set; }
        public bool IsDelete { get; set; }

        public static List<cComentario> NoticiaTodos(int pNoticiaId, string pUsuarioPK)
        {
            List<cComentario> auxComentarios = new List<cComentario>();
            using (DataTable dt= Funciones.ExecuteDataTable("PA_API_NOTICIA_COMENTARIOS",pNoticiaId,pUsuarioPK))
            {
                if (dt.Rows.Count < 1) return auxComentarios;
                foreach (DataRow dr in dt.Rows)
                {
                    auxComentarios.Add(new cComentario() {
                        NCId = int.Parse(dr["NC_ID"].ToString()),
                        Nombre = dr["C_NOMBRE_COMPLETO"].ToString(),
                        Comentario = dr["C_COMENTARIO"].ToString(),
                        Fecha = DateTime.Parse(dr["C_FECHA"].ToString()),
                        Imagen = dr["C_IMAGEN"].ToString(),
                        IsDelete = Convert.ToBoolean(int.Parse(dr["isDelete"].ToString()))
                    }
                    );
                }
            }
            return auxComentarios;
        }
        public static void NoticiaGuardar(int pNoticiaId,string pUsuarioPk,string pComentario)
        {
            long ncId=0;
            ncId= Funciones.ExecuteSqlIdentity("PA_API_NOTICIA_COMENTARIO_insert", pNoticiaId,pUsuarioPk,pComentario, ncId);
        }
        public static void NoticiaEliminar(int pNCId)
        {
            Funciones.ExecuteSql("PA_API_NOTICIA_COMENTARIO_delete", pNCId);
        }
    }
}