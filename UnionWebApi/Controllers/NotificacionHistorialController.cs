using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class NotificacionHistorialController : ApiController
    {
        // api/NotificacionHistorial?pIglesiaId=1
        public List<cNotificacion> GetNotificaciones(int pIglesiaId)
        {
            return cNotificacion.Historial(pIglesiaId);
        }
    }
}
