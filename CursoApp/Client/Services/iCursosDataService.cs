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
        Cursos GetCursoById(int cursoId);
        Cursos AddCurso(Cursos curso);
        Cursos UpdateCurso(Cursos curso);
        Task<int> GetCantCurso();
        void DeleteCursoById(int cursoId);
    }
}
