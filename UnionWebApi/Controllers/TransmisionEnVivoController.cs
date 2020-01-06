using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class TransmisionEnVivoController : ApiController
    {
        // api/TransmisionEnVivo?pId=1
        public cTransmisionEnVivo GetTransmisionEnVivo(int pId)
        {
            return cTransmisionEnVivo.TransmisionActual(pId);
        }

        // api/TransmisionEnVivo?pIdTransmision=1
        public cTransmisionEnVivo GetTransmisionEnVivoPorId(int pIdTransmision)
        {
            return cTransmisionEnVivo.PorId(pIdTransmision);
        }
    }
}
