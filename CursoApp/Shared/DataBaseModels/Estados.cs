using System;
using System.Collections.Generic;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Estados
    {
        public Estados()
        {
            Cursos = new HashSet<Cursos>();
        }

        public int IdEstado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
