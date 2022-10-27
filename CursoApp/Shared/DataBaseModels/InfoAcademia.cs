using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class InfoAcademia
    {
        [NotMapped]
        public int idEntidad { get => IdAcademia; set => IdAcademia = value; }

        [Key]
        public int IdAcademia { get; set; }

        [MaxLength(70)]
        public string Descripcion { get; set; }

    }
}
