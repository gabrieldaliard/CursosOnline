using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class PreguntasFreq
    {
        [NotMapped]
        public int idEntidad { get => IdPregunta; set => IdPregunta = value; }
        internal int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
    }
}
