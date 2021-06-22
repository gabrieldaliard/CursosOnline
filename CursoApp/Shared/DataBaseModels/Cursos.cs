using System;
using System.Collections.Generic;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Cursos
    {
        public Cursos()
        {
            UsuariosCursos = new HashSet<UsuariosCursos>();
        }

        public int IdCurso { get; set; }
        public string Titulo { get; set; }
        public int idInstructor { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? Interesados { get; set; }
        public int? Estudiantes { get; set; }
        public bool IdEstado { get; set; }
        public bool Destacado { get; set; }

        public virtual Instructores idInstructorNavigation { get; set; }
        public virtual ICollection<UsuariosCursos> UsuariosCursos { get; set; }
    }
}
