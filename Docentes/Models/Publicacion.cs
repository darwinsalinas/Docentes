using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Docentes.Models
{
    public class Publicacion
    {
        public int Id { get; set; }
        [DisplayName("Título"), Required]
        public string Titulo { get; set; }
        [Required]
        public string Año { get; set; }

        [DisplayName("Editorial"), Required]
        public int EditorialId { get; set; }
        public virtual Editorial Editorial { get; set; }

        [DisplayName("Tipo"), Required]
        public int TipoPublicacionId { get; set; }
        public virtual TipoPublicacion Tipo { get; set; }


        [DisplayName("Docente"), Required]
        public int DocenteId { get; set; }
        public virtual Docente Docente { get; set; }
    }
}