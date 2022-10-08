using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Shared.DataBaseModels
{
    public class Estados
    {
        public Estados()
        {

        }

        [NotMapped]
        public int idEntidad { get => IdEstado; set => IdEstado = value; }

        [Key]
        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstado { get; set; }


        [MaxLength(70)]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public int IdCurso { get; set; }
        public virtual ICollection<Cursos> Cursos { get; set; }

        [Required]
        public int IdInstructor { get; set; }
        public virtual ICollection<Instructores> Instructores { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }


    }
}
