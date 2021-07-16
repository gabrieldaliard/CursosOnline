using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApp.Api.Models
{
    interface IEntidadRepository
    {
        public IEnumerable<T> GetAllEntidades<T>();       
        public t GetEntidadById<t>(int xId);
        public t AddEntidad<t>(t obj);
        public void UpdateEntidad<t>(t obj);
        int GetCountEntidad();
        void DeleteEntidadById(int xId);
    }
}
