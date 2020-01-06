using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class UsuarioDepartamentoController : ApiController
    {
        public HttpResponseMessage PostUsuarioDepartamento(cUsuarioDepartamento pUsuarioDepartamento)
        {
            pUsuarioDepartamento.Suscribirse();
            var response = Request.CreateResponse<cUsuarioDepartamento>(HttpStatusCode.Created, pUsuarioDepartamento);
            string AuxUri = Url.Link("DefaultApi", new { id = pUsuarioDepartamento.UD_ID });
            response.Headers.Location = new Uri(AuxUri);
            return response;
        }
        public bool GetUsuarioDepartamento(string pUserId, long pDeptoId)
        {
            return cUsuarioDepartamento.EstaSuscrito(pUserId, pDeptoId);
        }
        public void DeleteUsuarioDepartamento(string pUserId, long pDeptoId)
        {
            cUsuarioDepartamento.Desuscribirse(pUserId, pDeptoId);
        }
    }
}
