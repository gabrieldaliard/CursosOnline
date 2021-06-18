// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // Paises
    public class Pais
    {
        public int IdPais { get; set; } // IdPais (Primary key)
        public string Descripcion { get; set; } // Descripcion (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Instructores where [Instructores].[IdPais] point to this entity (FK_Instructores_Pais)
        /// </summary>
        public virtual ICollection<Instructore> Instructores { get; set; } // Instructores.FK_Instructores_Pais

        /// <summary>
        /// Child Usuarios where [Usuarios].[IdPais] point to this entity (FK_Usuarios_Pais)
        /// </summary>
        public virtual ICollection<Usuario> Usuarios { get; set; } // Usuarios.FK_Usuarios_Pais

        public Pais()
        {
            Instructores = new List<Instructore>();
            Usuarios = new List<Usuario>();
        }
    }

}
// </auto-generated>