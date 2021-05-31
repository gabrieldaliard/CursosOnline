// <auto-generated>
// ReSharper disable All

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    // ****************************************************************************************************
    // This is not a commercial licence, therefore only a few tables/views/stored procedures are generated.
    // ****************************************************************************************************

    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Curso> Cursoes { get; set; } // Cursos
        public DbSet<Estado> Estadoes { get; set; } // Estados
        public DbSet<InfoAcademia> InfoAcademias { get; set; } // InfoAcademia
        public DbSet<Instructore> Instructores { get; set; } // Instructores
        public DbSet<Pais> Pais { get; set; } // Paises
        public DbSet<PreguntasFreq> PreguntasFreqs { get; set; } // PreguntasFreq
        public DbSet<Usuario> Usuarios { get; set; } // Usuarios
        public DbSet<UsuariosCurso> UsuariosCursoes { get; set; } // UsuariosCursos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-4ERJ3BTU\SQLEXPRESS; Initial Catalog = FlopiDiazTaller; Integrated Security = True");
            }
        }

        public bool IsSqlParameterNull(SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == DBNull.Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CursoConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());
            modelBuilder.ApplyConfiguration(new InfoAcademiaConfiguration());
            modelBuilder.ApplyConfiguration(new InstructoreConfiguration());
            modelBuilder.ApplyConfiguration(new PaisConfiguration());
            modelBuilder.ApplyConfiguration(new PreguntasFreqConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuariosCursoConfiguration());
        }

    }
}
// </auto-generated>
