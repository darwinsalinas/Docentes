using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Docentes.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        [DisplayName("Nombre del proyecto"), Required]
        public string Nombre { get; set; }
        [DisplayName("Duración"), Required]
        public string Duracion { get; set; }
        [DisplayName("Patrocinador"), Required]
        public string Patrocinador { get; set; }

        [DisplayName("Docente"), Required]
        public int DocenteId { get; set; }
        public Docente Docente { get; set; }

    }
}