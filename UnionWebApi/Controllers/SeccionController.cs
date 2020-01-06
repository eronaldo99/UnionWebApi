using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Model.Entities.Seccion;

namespace UnionWebApi.Controllers
{
    public class SeccionController : ApiController
    {
        public List<Seccion> GetTodas(int pIglesiaId)
        {
            return Seccion.Todas(pIglesiaId);
        }
    }
        
}
