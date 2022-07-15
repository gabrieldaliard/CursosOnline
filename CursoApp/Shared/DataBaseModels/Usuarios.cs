using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Email { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required]
        public int? IdPais { get; set; }
        public string Contraseña { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual ICollection<UsuariosCursos> UsuariosCursos { get; set; }
    }
}
