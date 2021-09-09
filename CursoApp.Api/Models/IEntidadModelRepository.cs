using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApp.Api.Models
{
    public interface IEntidadModelRepository<t> where t : class
    {
        public IEnumerable<t> GetAllEntidadesModel();       
        public t GetEntidadModelById(int xId);
        public t AddEntidadModel(t obj);
        public void UpdateEntidadModel(t obj);
        public int GetCountEntidadModel();
        public void DeleteEntidadModelById(int xId);
        
    }
}
