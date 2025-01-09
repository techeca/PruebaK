using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }

        [NotMapped] // No se almacena en la base de datos
        public HttpPostedFileBase ImagenArchivo { get; set; }
    }
}