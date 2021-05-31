using System;
using System.Collections.Generic;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class Paises
    {
        public Paises()
        {
            Instructores = new HashSet<Instructores>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdPais { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Instructores> Instructores { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
