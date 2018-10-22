using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Docentes.Models
{
    public class Editorial
    {
        public int Id { get; set; }
        [DisplayName("Editorial"), Required]
        public string Nombre { get; set; }

        public ICollection<Editorial> Editoriales { get; set; }
    }
}