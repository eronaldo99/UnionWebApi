using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Models.Entities;

namespace UnionWebApi.Controllers
{
    public class NoticiaComentarioController : ApiController
    {
        // api/NoticiaComentario?pNoticiaId=5&pUsuarioPK=1215
        public List<cComentario> GetNoticiaComentarios(int pNoticiaId,string pUsuarioPK)
        {
            return cComentario.NoticiaTodos(pNoticiaId, pUsuarioPK);
        }
        // api/NoticiaComentario?pNoticiaId=5&pUsuarioPK=1215&pComentario=aca
        public List<cComentario> GetNoticiaComentarioGuardar(int pNoticiaId, string pUsuarioPK,string pComentario)
        {
            cComentario.NoticiaGuardar(pNoticiaId, pUsuarioPK, pComentario);
            return cComentario.NoticiaTodos(pNoticiaId, pUsuarioPK);
        }
        // api/NoticiaComentario?pNCId=1&pNoticiaId=11&pUsuarioPK=123123
        public List<cComentario> GetNoticiaComentarioEliminar(int pNCId, int pNoticiaId, string pUsuarioPK)
        {
            cComentario.NoticiaEliminar(pNCId);
            return cComentario.NoticiaTodos(pNoticiaId, pUsuarioPK);
        }

    }
}
