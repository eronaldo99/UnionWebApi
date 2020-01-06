using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class TransmisionEnVivoTodosController : ApiController
    {
        // api/TransmisionEnVivoTodos?pId=1
        public List<cTransmisionEnVivo> GetTransmisionEnVivoTodos(int pId)
        {
            return cTransmisionEnVivo.Todas(pId);
        }
    }
}
