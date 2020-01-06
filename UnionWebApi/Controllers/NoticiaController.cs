using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class NoticiaController : ApiController
    {
        // api/Noticia?pId=4
        public cNoticia GetNoticia(int pId)
        {
            return cNoticia.getNoticia(pId);
        }
    }
}
