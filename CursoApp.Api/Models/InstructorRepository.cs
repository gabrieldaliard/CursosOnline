using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;

namespace CursoApp.Api.Models
{
    public class InstructorRepository<t> : IEntidadRepository<t> where t : class
    {
        private readonly AppDbContext _appDbContext;

        public InstructorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public t AddEntidad(t obj)
        {
            using (_appDbContext)
            {
                var newEntity = _appDbContext.Add(obj);
                _appDbContext.SaveChanges();
                return (t)newEntity.Entity;
            }
        }


        public void DeleteEntidadById(int xId)
        {
            using (_appDbContext)
            {
                var foundEntidad = _appDbContext.Set<t>().Find(xId);

                if (foundEntidad != null)
                {
                    _appDbContext.Remove(foundEntidad);
                    _appDbContext.SaveChanges();
                }
            }
        }


        public IEnumerable<t> GetAllEntidades()
        {
            try
            {
                return _appDbContext.Set<t>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los datos de los cursos.");
            }
        }

        public int GetCountEntidad()
        {
            return _appDbContext.Set<t>().Count();
        }

        public t GetEntidadById(int xId)
        {
            return _appDbContext.Set<t>().Find(xId);
        }

        public void UpdateEntidad(t obj)
        {
            using (_appDbContext)
            {
                var foundEntidad = _appDbContext.Entry(obj);

                if (foundEntidad != null)
                {
                    _appDbContext.Entry(foundEntidad).CurrentValues.SetValues(obj);
                    _appDbContext.SaveChanges();
                }
            }
        }
    }
}
