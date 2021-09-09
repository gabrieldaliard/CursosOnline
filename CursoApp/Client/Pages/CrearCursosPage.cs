using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Client.Services;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CursoApp.Client.Pages
{
    public partial class CrearCursosPage
    {
        [Inject]
        public iEntidadDataService<Cursos> CursoDataService { get; set; }
        [Inject]
        public iEntidadDataService<Instructores> InstructoresDataService { get; set; }

        public Cursos Curso { get; set; } = new Cursos();

        IEnumerable<Instructores> listaInstructores;
        private EditContext editContext;

        protected override async Task OnInitializedAsync()
        {
            listaInstructores = await InstructoresDataService.GetAllEntidades();

            editContext = new EditContext(Curso);
        }


        public async Task handleSubmmitAsync(Cursos xCurso)
        {
            await CursoDataService.AddEntidad(xCurso);
        }

        public void handleInvalidSubmmit()
        {

        }

    }
}
