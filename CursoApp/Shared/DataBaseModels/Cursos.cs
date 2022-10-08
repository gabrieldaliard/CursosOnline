using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Cursos : IEntidad
    {
        public Cursos()
        {
            UsuariosCursos = new HashSet<UsuariosCursos>();

        }

        public Cursos(int xIdCurso, string xTitulo)
        {
            IdCurso = xIdCurso;
            Titulo = xTitulo;

        }

        [NotMapped]
        public int idEntidad { get => IdCurso; set => IdCurso = value; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }

        [Required]
        [MaxLength(70)]
        public string Titulo { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? Interesados { get; set; }

        public int? Estudiantes { get; set; }

        public bool Destacado { get; set; }

        
        public int idInstructor { get; set; }
        public virtual Instructores Instructores { get; set; } //Indica que estamos haciendo referencia a una tabla externa

        [Required]
        public int IdEstado { get; set; }
        public Estados Estados { get; set; } //Indica que estamos haciendo referencia a una tabla externa

        public virtual ICollection<UsuariosCursos> UsuariosCursos { get; set; }
        
    }
}
