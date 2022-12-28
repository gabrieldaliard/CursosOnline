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
            //UsuariosCursos = new HashSet<UsuariosCursos>();
        }

        [NotMapped]
        public int idEntidad { get => IdUsuario; set => IdUsuario = value; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public DateTime? UltimoAcceso { get; set; }        
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public int Dni { get; set; }

        [Required]
        public int IdPais { get; set; }
        public Paises Paises { get; set; } //Indica que estamos haciendo referencia a una tabla externa
             
        [Required]
        public int IdEstado { get; set; }
        public Estados Estados { get; set; } //Indica que estamos haciendo referencia a una tabla externa

        public int IdCursos { get; set; }
        public ICollection<Cursos> Cursos { get; set; }


    }
}
