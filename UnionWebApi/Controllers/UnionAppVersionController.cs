using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class UnionAppVersionController : ApiController
    {
        // api/UnionAppVersion
        public string GetUnionAppVersion()
        {
            return cParametro.getValue("APP_VERSION");
        }
    }
}
