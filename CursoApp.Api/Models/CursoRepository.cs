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
            using (_appDbContext)
            {
                var newEntity = _appDbContext.Cursos.Add(curso);
                _appDbContext.SaveChanges();
                return newEntity.Entity;
            }
        }

        public void DeleteCursoById(int xId)
        {
            using (_appDbContext)
            {
                _appDbContext.Cursos.Remove(_appDbContext.Cursos.FirstOrDefault(c => c.idEntidad == xId));
                _appDbContext.SaveChanges();
            }
                
        }

        public IEnumerable<Cursos> GetAllCursos()
        {
            try
            {
                var res = _appDbContext.Cursos;
                return res;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al obtener los datos de los cursos.");
            }
            
        }

        public int GetCountCurso()
        {
            return _appDbContext.Cursos.Count();
        }

        public Cursos GetCursoById(int xId)
        {
            return _appDbContext.Cursos.FirstOrDefault(c => c.idEntidad == xId);
        }

        public void UpdateCurso(Cursos curso)
        {
            using (_appDbContext)
            {
                var foundCurso = _appDbContext.Cursos.FirstOrDefault(e => e.idEntidad == curso.idEntidad);

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
                    
                }

                throw new Exception("Error al actualizar el curso.");
            }              

        }
    }
}
