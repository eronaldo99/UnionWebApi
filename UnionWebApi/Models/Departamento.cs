using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionWebApi.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        public int I_ID { get; set; }

        public string DT_PK { get; set; }

        public string D_RESPONSABLE { get; set; }

        public string D_IMAGEN { get; set; }

        public string D_EMAIL { get; set; }

        public string D_TELEFONO { get; set; }

        public bool deleted { get; set; }

        public string version { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}