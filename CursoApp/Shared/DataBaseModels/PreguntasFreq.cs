using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class PreguntasFreq
    {
        [NotMapped]
        public int idEntidad { get => IdPregunta; set => IdPregunta = value; }

        public PreguntasFreq()
        {

        }

        public PreguntasFreq(int xIdPregunta, string xPregunta, string xRespuesta)
        {
            IdPregunta = xIdPregunta;
            Pregunta = xPregunta;   
            Respuesta = xRespuesta;
        }

        [Key]
        public int IdPregunta { get; set; }
        [Required]
        public string Pregunta { get; set; }
        [Required]
        public string Respuesta { get; set; }
    }
}
