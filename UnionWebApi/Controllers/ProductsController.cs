using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;
using UnionWebApi.Models;

namespace UnionWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3 },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16 }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        // api/products
        //public HttpResponseMessage GetAllProductss()
        //{
        //    //DataClassesDataContext cn = new DataClassesDataContext();
        //    //var result = (from entry in cn.GetTable<DEPARTAMENTO>().AsEnumerable<DEPARTAMENTO>()
        //    //              select entry).ToList();
        //    //return Request.CreateResponse<List<DEPARTAMENTO>>(HttpStatusCode.OK, result);

        //    using (DataTable dt = Funciones.ExecuteDataTable("SELECT * FROM DEPARTAMENTO"))
        //    {
        //        return new HttpResponseMessage()
        //        {
        //            Content = new StringContent(JsonConvert.SerializeObject(dt), System.Text.Encoding.UTF8, "application/json")
        //        };
        //    }
        //}

        // api/products
        public HttpResponseMessage PostProductList(Dictionary<string, List<cEntidadSync>> pDictionary)
        {
            var x = pDictionary.FirstOrDefault().Value;
            XElement xml = new XElement("ES", x.Select(i => new XElement("E", new XAttribute("Key", i.Key), new XAttribute("Version", i.Version), new XAttribute("Deleted", i.Deleted))));
            DataTable dt = Funciones.ExecuteDataTable("PA_TABLE_ENTIDAD_GET_LAST_VERSION", pDictionary.First().Key,xml.ToString());
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(dt), System.Text.Encoding.UTF8, "application/json")
            };

            //var aux2 = JsonConvert.SerializeObject(aux);
            ////   Json(aux, JsonRequestBehavior.AllowGet);
            //return Request.CreateResponse<string>(HttpStatusCode.OK, aux2);
            //;
        }

        // api/prodcuts
        //public HttpResponseMessage PostProduct(string pJson)
        //{
        //    List<DEPARTAMENTO> aux = new List<DEPARTAMENTO>();
        //    var response = Request.CreateResponse<List<DEPARTAMENTO>>(HttpStatusCode.OK, aux);
        //    return response;
        //}
        //public HttpResponseMessage PostProductList<T>(List<T> pObject) where T :class, iKeyObject, new()
        //{
        //    DataClassesDataContext cn = new DataClassesDataContext();
        //    var result = (from entry in cn.GetTable<T>().AsEnumerable<T>()
        //                   join entry2 in pObject on entry.Key equals entry2.Key
        //                   //where entry.Key =="1"
        //                  select entry).ToList();
        //    return Request.CreateResponse<List<T>>(HttpStatusCode.OK, result);
        //}
        //public HttpResponseMessage PostProductList()
        //{
        //    DataClassesDataContext cn = new DataClassesDataContext();
        //    var result = (from entry in cn.GetTable<DEPARTAMENTO>().AsEnumerable<DEPARTAMENTO>()
        //                  select entry).ToList();
        //    return Request.CreateResponse<List<DEPARTAMENTO>>(HttpStatusCode.OK, result);
        //}
    }
}
