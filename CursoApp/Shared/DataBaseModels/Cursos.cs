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
        [NotMapped]
        public int idEntidad { get => IdCurso; set => IdCurso = value; }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCurso { get; set; }

        [Required]
        [MaxLength(70)]
        public string Titulo { get; set; }

        [Required]
        public int idInstructor { get; set; }

        
        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        
        public int? Interesados { get; set; }

        public int? Estudiantes { get; set; }

        public bool Destacado { get; set; }

        public Estados IdEstado { get; set; }

        public virtual Instructores idInstructorNavigation { get; set; }
        //public virtual Estados IdEstado { get; set; }
        public virtual ICollection<UsuariosCursos> UsuariosCursos { get; set; }
        
    }
}
