using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Client.Services;
using CursoApp.Shared.DataBaseModels;
using CursoApp.Shared;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace CursoApp.Client.Pages
{
    public partial class CursosPage
    {
        [Inject]
        public iCursosDataService CursoDataService { get; set; }

        IEnumerable<Cursos> xCurso;



        protected override async Task OnInitializedAsync()
        {            
            xCurso = await CursoDataService.GetAllCursos();
        }


    }

}
