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
            void UpdateCurso(Cursos curso);
            int GetCountCurso();
            void DeleteCursoById(int cursoId);

            
            
    }
}
