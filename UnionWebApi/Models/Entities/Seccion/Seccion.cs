using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionWebApi.Models;

namespace UnionWebApi.Model.Entities.Seccion
{
    public class Seccion
    {
        public int SIT_ID { get; set; }
        public int I_ID { get; set; }
        public string SIT_TITULO { get; set; }
        public string SIT_TIPO { get; set; }
        public double SIT_RATING_MAX { get; set; }
        public DateTime SIT_FECHA_SISTEMA { get; set; }
        public int SIT_ORDEN { get; set; }
        public List<Item> ItemList { get; set; }

        public Seccion()
        {
        }
        public static List<Seccion> Todas(int pIglesiaId)
        {
            var secciones = new List<Seccion>();
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_SECCION_HOME", pIglesiaId))
            {
                if (dt.Rows.Count > 0)
                {
                    int auxSeccionId = 0;
                    int i = 1;
                    Seccion seccion = null;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (auxSeccionId == 0)
                        {
                            seccion = new Seccion()
                            {
                                SIT_TIPO = dr["SIT_TIPO"].ToString(),
                                SIT_TITULO = dr["SIT_TITULO"].ToString(),
                                ItemList = new List<Item>()
                            };
                            auxSeccionId = int.Parse(dr["SIT_ID"].ToString());
                        }
                        else if (auxSeccionId != int.Parse(dr["SIT_ID"].ToString()))
                        {
                            secciones.Add(seccion);
                            seccion = new Seccion()
                            {
                                SIT_TIPO = dr["SIT_TIPO"].ToString(),
                                SIT_TITULO = dr["SIT_TITULO"].ToString(),
                                ItemList = new List<Item>()
                            };
                            auxSeccionId = int.Parse(dr["SIT_ID"].ToString());
                        }
                        seccion.ItemList.Add(
                            new Item() {
                                IT_DESCRIPCION=dr["IT_DESCRIPCION"].ToString(),
                                IT_EMAIL= dr["IT_EMAIL"].ToString(),
                               // IT_FECHA= string.IsNullOrEmpty(dr["IT_FECHA"].ToString())? DateTime.MinValue: DateTime.Parse(dr["IT_FECHA"].ToString()),
                                IT_ID= int.Parse(dr["IT_ID"].ToString()),
                                IT_IMAGEN_URL= dr["IT_IMAGEN_URL"].ToString(),
                               // IT_RATING_VALUE= string.IsNullOrEmpty(dr["IT_RATING_VALUE"].ToString()) ? 5: double.Parse( dr["IT_RATING_VALUE"].ToString()),
                                IT_TELEFONO= dr["IT_TELEFONO"].ToString(),
                                IT_TITULO= dr["IT_TITULO"].ToString(),
                                IT_URL= dr["IT_URL"].ToString()
                            }
                            );
                        if (dt.Rows.Count == i)
                            secciones.Add(seccion);
                        i++;
                    }
                }
            }
            return secciones;
        }
    }
}
