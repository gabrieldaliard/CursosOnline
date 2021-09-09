using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CursoApp.Api.Models
{
    public class EntidadModelRepository<t> : IEntidadModelRepository<t> where t : class
    {
        private readonly AppDbContext _appDbContext;

        public EntidadModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public t AddEntidadModel(t obj)
        {
            using (_appDbContext)
            {
                var newEntity = _appDbContext.Add(obj);
                _appDbContext.SaveChanges();
                return (t)newEntity.Entity;
            }
        }


        public void DeleteEntidadModelById(int xId)
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


        public IEnumerable<t> GetAllEntidadesModel()
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

        public int GetCountEntidadModel()
        {
            return _appDbContext.Set<t>().Count();
        }

        public t GetEntidadModelById(int xId)
        {
            return _appDbContext.Set<t>().Find(xId);            
        }
       
        public void UpdateEntidadModel(t obj)
        {
            using (_appDbContext)
            {                
                var foundEntidad = _appDbContext.Find<t>(obj);

                //var currentEntity = dbSetEntity.Find(id);
                //_dbContext.Entry(currentEntity).CurrentValues.SetValues(newValues);

                if (foundEntidad != null)
                {

                    _appDbContext.Entry(foundEntidad).CurrentValues.SetValues(obj);
                    _appDbContext.SaveChanges();
                }                        
            }
        }

    }
}
