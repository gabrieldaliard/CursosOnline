using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;
using Microsoft.Data.SqlClient;

namespace CursoApp.Api.Models
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _appDbContext;

        public CursoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Cursos AddCurso(Cursos curso)
        {
            var newEntity = _appDbContext.Cursos.Add(curso);
            _appDbContext.SaveChanges();
            return newEntity.Entity;
        }

        public void DeleteCursoById(int cursoId)
        {
            _appDbContext.Cursos.Remove(_appDbContext.Cursos.FirstOrDefault(c => c.IdCurso == cursoId));
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Cursos> GetAllCursos()
        {
            return _appDbContext.Cursos;
        }

        public int GetCantCurso()
        {
            return _appDbContext.Cursos.Count();
        }

        public Cursos GetCursoById(int cursoId)
        {
            return _appDbContext.Cursos.FirstOrDefault(c => c.IdCurso == cursoId);
        }

        public Cursos UpdateCurso(Cursos curso)
        {
            var foundCurso = _appDbContext.Cursos.FirstOrDefault(e => e.IdCurso == curso.IdCurso);

            if (foundCurso != null)
            {
                foundCurso.Titulo = curso.Titulo;
                foundCurso.idInstructor = curso.idInstructor;
                foundCurso.IdEstado = curso.IdEstado;
                foundCurso.FechaModificacion = curso.FechaModificacion;
                foundCurso.Interesados = curso.Interesados;
                foundCurso.Estudiantes = curso.Estudiantes;
                foundCurso.Destacado = curso.Destacado;

                _appDbContext.SaveChanges();

                return foundCurso;
            }

            return null;

        }
    }
}
