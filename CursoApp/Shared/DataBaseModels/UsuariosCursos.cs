using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class UsuariosCursos
    {
        [NotMapped]
        public int idEntidad { get => Id; set => Id = value; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdCurso { get; set; }
        public virtual ICollection<Cursos> Cursos { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }


    }
}
