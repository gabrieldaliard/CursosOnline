using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApp.Api.Models
{
    public interface IEntidadRepository<t> where t : class
    {
        public IEnumerable<t> GetAllEntidades();       
        public t GetEntidadById(int xId);
        public t AddEntidad(t obj);
        public void UpdateEntidad(t obj);
        public int GetCountEntidad();
        public void DeleteEntidadById(int xId);
    }
}
