using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;

namespace CursoApp.Api.Models
{
    public interface ICursoRepository
    {
            IEnumerable<Cursos> GetAllCursos();
            Cursos GetCursoById(int cursoId);
            Cursos AddCurso(Cursos curso);
            Cursos UpdateCurso(Cursos curso);
            int GetCantCurso();
            void DeleteCursoById(int cursoId);
    }
}
