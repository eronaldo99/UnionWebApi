using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models;

namespace UnionWebApi.Controllers
{
    public class IglesiaController : ApiController
    {
        public HttpResponseMessage GetIglesias()
        {
            using (DataTable dt = Funciones.ExecuteDataTable("SELECT * FROM IGLESIA"))
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(dt), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
