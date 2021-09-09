using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Components;
using CursoApp.Client.Services;

namespace CursoApp.Client.Pages
{
    public partial class DetalleCursoPage
    {
        [Parameter]
        public int CursoId { get; set; }

        [Inject]
        public iEntidadDataService<Cursos> CursoDataService { get; set; }
        [Inject]
        public iEntidadDataService<Instructores> InstructoresDataService { get; set; }

        IEnumerable<Cursos> curso;
        IEnumerable<Instructores> listaInstructores;

        protected override async Task OnInitializedAsync()
        {
            listaInstructores = await InstructoresDataService.GetAllEntidades();
            if (CursoId == 0)
            {
                // directamente tirar error!
                
            }
            else
            {
                Curso = await CursoDataService.GetEntidadById(CursoId);
               
            }


        }

        public Cursos Curso { get; set; } = new Cursos();

        public async Task handleSubmmit()
        {
            await CursoDataService.UpdateEntidad(Curso);
        }

        public void handleInvalidSubmmit()
        {

        }


    }
}
