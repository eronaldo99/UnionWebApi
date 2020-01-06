using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models.Entities.Seccion;

namespace UnionWebApi.Controllers
{
    public class ItemPrincipalController : ApiController
    {
        public ItemPrincipal Get(int pIglesiaId)
        {
            return ItemPrincipal.Principal(pIglesiaId);
        }
    }
}
