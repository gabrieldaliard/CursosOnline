using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Paises
    {
        public Paises()
        {

        }

        [NotMapped]
        public int idEntidad { get => IdPais; set => IdPais = value; }

        [Key]
        [Required]
        public int IdPais { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Instructores> Instructores { get; set; }

    }
}
