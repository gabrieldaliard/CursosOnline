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

        //Requerido
        public Instructores(int xidInstructor, string xNombre, int xIdPais)
        {
            IdInstructor = xidInstructor;
            IdPais = xIdPais;
            Nombre = xNombre;
        }


        public Instructores(int xidInstructor, string xNombre, string xApellido, string xDescripcion, int xIdPais, ICollection<Cursos> xCursos)
        {
            IdInstructor = xidInstructor;
            IdPais = xIdPais;
            Nombre = xNombre;
            Apellido = xApellido;   
            Descripcion = xDescripcion;
            Cursos = xCursos;

        }

        [NotMapped]
        public int idEntidad { get => IdInstructor; set => IdInstructor = value; }

        [Key]
        public int IdInstructor { get; set; } 

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellido { get; set; }
        [MaxLength(100)]
        public string Descripcion { get; set; }


        [Required]
        public int IdEstado { get; set; }
        public Estados Estados { get; set; } //Indica que estamos haciendo referencia a una tabla externa

        [Required]
        public int IdPais { get; set; }
        public virtual Paises Paises { get; set; }

        
        public int IdCurso { get; set; }
        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
