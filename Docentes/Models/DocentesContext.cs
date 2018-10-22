using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Docentes.Models
{
    public class DocentesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DocentesContext() : base("name=DocentesContext")
        {
        }

        public System.Data.Entity.DbSet<Docentes.Models.Proyecto> Proyectoes { get; set; }

        public System.Data.Entity.DbSet<Docentes.Models.Docente> Docentes { get; set; }

        public System.Data.Entity.DbSet<Docentes.Models.Publicacion> Publicacions { get; set; }

        public System.Data.Entity.DbSet<Docentes.Models.Editorial> Editorials { get; set; }

        public System.Data.Entity.DbSet<Docentes.Models.TipoPublicacion> TipoPublicacions { get; set; }

        public System.Data.Entity.DbSet<Docentes.Models.Estudiante> Estudiantes { get; set; }
    }
}
