using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Instructores : IEntidad
    {
        public Instructores()
        {
            Cursos = new HashSet<Cursos>();
        }

        [NotMapped]
        public int idEntidad { get => IdInstructor; set => IdInstructor = value; }

        [Key]
        public int IdInstructor { get; set; } 

        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripción { get; set; }
        [Required]
        public int IdPais { get; set; }

        public virtual Paises IdPaisNavigation { get; set; }
        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
