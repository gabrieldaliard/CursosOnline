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
        public iCursosDataService CursoDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (CursoId == 0)
            {
                // directamente tirar error!
            }
            else
            {
                Curso = await CursoDataService.GetCursoById(CursoId);
            }


        }

        public Cursos Curso { get; set; } = new Cursos();

        public async Task handleSubmmit()
        {
            await CursoDataService.UpdateCurso(Curso);
        }

        public void handleInvalidSubmmit()
        {

        }
    }
}
