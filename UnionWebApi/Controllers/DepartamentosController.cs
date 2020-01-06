using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class DepartamentosController : ApiController
    {
        // api/Departamentos?pId=1
        public HttpResponseMessage GetDepartamentos(int pId)
        {
            using (DataTable dt = Funciones.ExecuteDataTable("SELECT D_ID,DT_PK FROM DEPARTAMENTO WHERE I_ID="+pId.ToString()))
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JsonConvert.SerializeObject(dt), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
