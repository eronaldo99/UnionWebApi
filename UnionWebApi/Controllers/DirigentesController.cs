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
    public class DirigentesController : ApiController
    {
        // api/Dirigentes?pIglesiaId=1
        public List<cDirigente> GetDirigentes(int pIglesiaId)
        {
            return cDirigente.Todos(pIglesiaId);
        }
    }
}
