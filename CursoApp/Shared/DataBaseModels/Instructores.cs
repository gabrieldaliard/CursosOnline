using System;
using System.Collections.Generic;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Instructores
    {
        public Instructores()
        {
            Cursos = new HashSet<Cursos>();
        }

        public int IdInstructor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripción { get; set; }
        public int IdPais { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
