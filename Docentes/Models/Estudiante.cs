using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Docentes.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        [DisplayName("Nombres"), Required]
        public string Nombres { get; set; }
        [DisplayName("Apellidos"), Required]
        public string Apellidos { get; set; }
        [DisplayName("Edad"), Required]
        public int Edad { get; set; }
        [DisplayName("Teléfono"), Required]
        public string Telefono { get; set; }
    }
}