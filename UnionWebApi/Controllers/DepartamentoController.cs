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
    public class DepartamentoController : ApiController
    {
        // api/Departamento?pId=5
        public cDepartamento GetDepartamentos(int pId)
        {
            return new cDepartamento(pId);
        }
    }
}
