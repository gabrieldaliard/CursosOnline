using CursoApp.Shared.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApp.Client.Services
{
    public interface iEntidadDataService<t> where t : class
    {
        public Task<IEnumerable<t>> GetAllEntidades();
        public Task<t> GetEntidadById(int xId);
        public Task<t> AddEntidad(t obj);
        public Task UpdateEntidad(t obj);
        public Task<int> GetCantEntidad();
        public Task DeleteEntidadById(int xId);
    }
}

