using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Docentes.Models
{
    public class TipoPublicacion
    {
        public int Id { get; set; }
        [DisplayName("Tipo"), Required]
        public string Tipo { get; set; }

        public ICollection<Publicacion> Publicaciones { get; set; }
    }
}