using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Docentes.Models
{
    public class Docente
    {
        public int Id { get; set; }
        [DisplayName("Nombres"), Required]
        public string Nombres { get; set; }
        [DisplayName("Apellidos"), Required]
        public string Apellidos { get; set; }
        [DisplayName("No INSS"), Required]
        public string Inss { get; set; }
        [DisplayName("Imagen")]
        public string Imagen { get; set; }


        public ICollection<Proyecto> Proyectos { get; set; }
        public ICollection<Publicacion> Publicaciones { get; set; }


        public virtual string FullName
        {
            get { return $"{Nombres} {Apellidos}";  }
        }

    }
}