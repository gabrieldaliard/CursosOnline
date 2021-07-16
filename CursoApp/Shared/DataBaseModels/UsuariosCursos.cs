using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class UsuariosCursos
    {
        [NotMapped]
        public int idEntidad { get => Id; set => Id = value; }
        internal int Id { get; set; }
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }

        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
