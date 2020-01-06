using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class UsuarioAsignarIglesiaController : ApiController
    {
        public HttpResponseMessage PostUsuarioAsignarIglesia(cUsuario pUsuario)
        {
            pUsuario.AsignarIglesia();
            var response = Request.CreateResponse<cUsuario>(HttpStatusCode.Created, pUsuario);
            string AuxUri = Url.Link("DefaultApi", new { id = pUsuario.C_PK });
            response.Headers.Location = new Uri(AuxUri);
            return response;
        }
    }
}
