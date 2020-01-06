using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace UnionWebApi.Models.Entities
{
    public class cNoticiaEstructura
    {
        public long N_ID { get; set; }
        public String NET_PK { get; set; }
        public String NE_TEXTO { get; set; }

        public cNoticiaEstructura(long pNid,string pTipo,string pValue)
        {
            this.N_ID = pNid;
            this.NET_PK = pTipo;
            this.NE_TEXTO = pValue;
        }
        public cNoticiaEstructura()
        {
           
        }
        public static IEnumerable<cNoticiaEstructura> GetNoticiaEstructura(int pId)
        {
            List<cNoticiaEstructura> estructuraList = new List<cNoticiaEstructura>();
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_NOTICIA_ESTRUCTURA", pId))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string auxValue = string.Empty;
                    switch (dr["NET_PK"].ToString())
                    {
                        case "TEXTO":
                            auxValue = dr["NE_TEXTO"].ToString().Replace("\"", "'");
                            break;
                        case "IMAGENES":
                            var imgl = dr["NE_TEXTO"].ToString().Split(';');
                            foreach (string img in imgl)
                            {
                                auxValue += cDatos.ArchivoRutaWeb() + img +";";
                            }
                            auxValue = auxValue.Remove(auxValue.Length - 1);
                            break;
                        case "VIDEO":
                            auxValue = dr["NE_TEXTO"].ToString().Replace("\"", "'");
                            break;
                    }
                    var n = new cNoticiaEstructura();
                    n.NET_PK = dr["NET_PK"].ToString();
                    n.NE_TEXTO = auxValue;
                    n.N_ID = long.Parse(dr["NE_ID"].ToString());
                    estructuraList.Add(n);
                  //  estructuraList.Add(new cNoticiaEstructura(long.Parse(dr["NE_ID"].ToString()), dr["NET_PK"].ToString(), auxValue));
                }
            }
            return estructuraList;
        }

        //public cNoticiaEstructura(int pId)
        //{
        //    using (DataTable dt = Funciones.ExecuteDataTable("PA_API_NOTICIA_ESTRUCTURA", pId))
        //    {
        //        int galleryCount = 1;
        //        string auxDescripcion = string.Empty;
        //        string auxCSS = String.Empty;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            switch (dr["NET_PK"].ToString())
        //            {
        //                case "TEXTO":
        //                    auxDescripcion += dr["NE_TEXTO"].ToString().Replace("\"","'");
        //                    break;
        //                case "IMAGENES":
        //                    List<string> imagenes = dr["NE_TEXTO"].ToString().Split(';').ToList();
        //                    auxDescripcion += this.GalleryToHTML(imagenes, galleryCount);
        //                    galleryCount += 1;
        //                    break;
        //            }
        //            auxDescripcion += "<br />";
        //        }
        //        for(int i=1;i<galleryCount;i++)
        //        {
        //            auxCSS += "<link href='gallery"+i.ToString()+".css' media='screen, projection' rel='stylesheet' type='text/css' />";
        //        }
        //        this.N_ID = pId;
        //        this.Descripcion = "<html><head>"+ auxCSS + "</head><body><input checked type='radio' name='respond' id='mobile' />" + auxDescripcion+ "</body></html>";
        //    }
        //}
        //private string GalleryToHTML(List<string> imagenes, int pGalleryCount)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string auxCheckbox = string.Empty;
        //    string auxImagenes = string.Empty;
        //    string auxControls = string.Empty;
        //    this.getAtributosGallery(imagenes, pGalleryCount,ref auxCheckbox, ref auxImagenes, ref auxControls);
        //    sb.AppendFormat("<article id='slider{0}'>{1}<div id='slides{0}'><div id='overflow'><div class='inner'>{2}</div></div></div><div id='controls'>{3}</div><div id='active'>{4}</div></article>", pGalleryCount.ToString(),auxCheckbox,auxImagenes,auxControls, auxControls);
        //    return sb.ToString();
        //}
        //private void getAtributosGallery(List<string> imagenes, int pGalleryCount,ref string pCheckBox,ref string pImages,ref string pControls)
        //{
        //    string SlidePrefijo = (pGalleryCount - 1).ToString();
        //    if (SlidePrefijo == "0") SlidePrefijo = "";
        //    for (int i = 1; i<=imagenes.Count; i++)
        //    {
        //        //checkbox
        //        if(i==1)
        //            pCheckBox += "<input checked type='radio' name='slider"+ pGalleryCount.ToString() + "' id='slide"+ SlidePrefijo+ i.ToString()+"' />";
        //        else
        //            pCheckBox += "<input type='radio' name='slider"+pGalleryCount.ToString()+"' id='slide"+ SlidePrefijo + i.ToString()+"' />";
        //        //llenando imagenes
        //        pImages += "<article><img src='"+cDatos.ArchivoRutaWeb()+imagenes[i-1] +"' /></article>";
        //        //llenando controls
        //        pControls += "<label for='slide"+ SlidePrefijo + i.ToString()+"'></label>";
        //    }
        //}
    }
}