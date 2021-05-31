using System;
using System.Collections.Generic;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class UsuariosCursos
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
