using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class NoticiaEstructuraController : ApiController
    {
        // api/NoticiaEstructura?pId=4
        public HttpResponseMessage GetNoticiaEstructura(int pId)
        {
            var aux = cNoticiaEstructura.GetNoticiaEstructura(pId);
            return new HttpResponseMessage()
            {
                Content = new StringContent(JArray.FromObject(aux).ToString(), Encoding.UTF8, "application/json")
            };
        }
        //public HttpResponseMessage GetNoticiaEstructura(int pId)
        //{
        //    var aux = cNoticiaEstructura.GetNoticiaEstructura(pId);
        //    var json = new JavaScriptSerializer().Serialize(aux);
        //    return Request.CreateResponse(HttpStatusCode.OK, json);
        //}
        //public IEnumerable<cNoticiaEstructura> GetNoticiaEstructura(int pId)
        //{
        //    var x= cNoticiaEstructura.GetNoticiaEstructura(pId);
        //    return x;
        //}
        //    public List<DataModel> GetNoticiaEstructura()
        //    {
        //        var data = new List<DataModel>()   {
        //        new DataModel() { Date = "", Users = 100},
        //        new DataModel() { Date = "", Users = 120}
        //};

        //      return data;

        //    }
        //public HttpResponseMessage GetNoticiaEstructura()
        //{
        //    var data = new List<DataModel>()
        //{
        //    new DataModel() {Date ="", Users = 100},
        //    new DataModel() {Date = "", Users = 120}
        //};

        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(JArray.FromObject(data).ToString(), Encoding.UTF8, "application/json")
        //    };
        //}

        //public IEnumerable<cNoticia> GetNoticiaEstructura()
        //{
        //    List<cNoticia> logins = new List<cNoticia>();
        //    cNoticia aux = new cNoticia();
        //    aux.A_ID = "";
        //    aux.Imagen = "";
        //    aux.N_FECHA_SISTEMA = DateTime.Now;
        //    aux.N_ID = 1;
        //    aux.N_TITULO = "titulo";
        //    logins.Add(aux);
        //    return logins;
        //}
    }
    //public class DataModel
    //{
    //    public string Date { get; set; }
    //    public int Users { get; set; }
    //}
}
