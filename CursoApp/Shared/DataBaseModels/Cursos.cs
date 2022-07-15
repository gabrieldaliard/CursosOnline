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

        //[Required]
        //public int idInstructor { get; set; }


        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? Interesados { get; set; }

        public int? Estudiantes { get; set; }

        public bool Destacado { get; set; }



        [ForeignKey("Estados")] //Para más info mirar https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
        public int IdEstado { get; set; }

        //IdInstructor podría no estar ya que debajo ya se infiere cual es la pk y en sql se generaria igual.
        //el problema es que no lo podría acceder desde nuestro código.
        [ForeignKey("Instructores")]
        public int idInstructor { get; set; }


        public virtual Instructores Instructores { get; set; }
        public virtual Estados Estados { get; set; } //Indica que estamos haciendo referencia a una tabla externa

        public virtual ICollection<UsuariosCursos> UsuariosCursos { get; set; }
        
    }
}
