using CursoApp.Shared.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoApp.Client.Services
{
    public interface iCursosDataService
    {
        public Task<IEnumerable<Cursos>> GetAllCursos();
        public Task<Cursos> GetCursoById(int cursoId);
        public Task<Cursos> AddCurso(Cursos curso);
        public Task UpdateCurso(Cursos curso);
        public Task<int> GetCantCurso();
        public Task DeleteCursoById(int cursoId);
    }
}
