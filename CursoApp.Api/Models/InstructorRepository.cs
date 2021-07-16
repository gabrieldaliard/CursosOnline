using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;

namespace CursoApp.Api.Models
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _appDbContext;

        public InstructorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Instructores AddInstructor(Instructores xInstructor)
        {
            using (_appDbContext)
            {
                var newEntity = _appDbContext.Instructores.Add(xInstructor);
                _appDbContext.SaveChanges();
                return newEntity.Entity;
            }
        }

        public void DeleteInstructorById(int xInstructorId)
        {
            using (_appDbContext)
            {
                _appDbContext.Instructores.Remove(_appDbContext.Instructores.FirstOrDefault(c => c.idEntidad == xInstructorId));
                _appDbContext.SaveChanges();
            }

        }

        public IEnumerable<Instructores> GetAllInstructores()
        {
            return _appDbContext.Instructores;
        }

        public int GetCountInstructor()
        {
            return _appDbContext.Instructores.Count();
        }

        public Instructores GetInstructorById(int xInstructorId)
        {
            return _appDbContext.Instructores.FirstOrDefault(c => c.idEntidad == xInstructorId);
        }

        public void UpdateInstructor(Instructores xInstructor)
        {
            using (_appDbContext)
            {
                var foundInstructor = _appDbContext.Instructores.FirstOrDefault(e => e.idEntidad == xInstructor.idEntidad);

                if (foundInstructor != null)
                {
                    foundInstructor.Apellido = xInstructor.Apellido;
                    foundInstructor.Cursos = xInstructor.Cursos;
                    foundInstructor.Descripción = xInstructor.Descripción;
                    foundInstructor.IdPais = 1;
                    foundInstructor.Nombre = xInstructor.Nombre;

                    _appDbContext.SaveChanges();

                }

                throw new Exception("Error al actualizar el Instructor.");
            }

        }
    }
}
