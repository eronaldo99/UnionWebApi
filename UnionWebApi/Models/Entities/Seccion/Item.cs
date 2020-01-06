using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionWebApi.Model.Entities.Seccion
{
    public class Item
    {
        public int IT_ID { get; set; }
        public string IT_TITULO { get; set; }
        public string IT_DESCRIPCION { get; set; }
        public string IT_IMAGEN_URL { get; set; }
        public DateTime IT_FECHA { get; set; }
        public double IT_RATING_VALUE { get; set; }
        public string IT_URL { get; set; }
        public string IT_TELEFONO { get; set; }
        public string IT_EMAIL { get; set; }
        public DateTime IT_FECHA_SISTEMA { get; set; }
    }
}
