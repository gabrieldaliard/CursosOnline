using CursoApp.Shared.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Api.Models
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructores> GetAllInstructores();
        Instructores GetInstructorById(int instructorId);
        Instructores AddInstructor(Instructores instructor);
        void UpdateInstructor(Instructores instructor);
        int GetCountInstructor();
        void DeleteInstructorById(int instructorId);
    }
}
