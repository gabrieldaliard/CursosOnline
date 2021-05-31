using System;
using System.Collections.Generic;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class PreguntasFreq
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
    }
}
