using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuariosCursos = new HashSet<UsuariosCursos>();
        }

        [NotMapped]
        public int idEntidad { get => IdUsuario; set => IdUsuario = value; }
        internal int IdUsuario { get; set; }
        public string Email { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? IdPais { get; set; }
        public string Contraseña { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual ICollection<UsuariosCursos> UsuariosCursos { get; set; }
    }
}
