using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class InfoAcademia
    {
        [NotMapped]
        public int idEntidad { get => IdAcademia; set => IdAcademia = value; }

        internal int IdAcademia { get; set; }
    }
}
