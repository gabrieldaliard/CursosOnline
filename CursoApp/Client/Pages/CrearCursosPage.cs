using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Client.Services;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;



namespace CursoApp.Client.Pages
{
    public partial class CrearCursosPage
    {
        [Inject]
        public iEntidadDataService<Cursos> CursoDataService { get; set; }
        [Inject]
        public iEntidadDataService<Instructores> InstructoresDataService { get; set; }
        [Inject]
        public iEntidadDataService<Estados> EstadosDataService { get; set; }

        public Cursos Curso { get; set; } = new Cursos();

        IEnumerable<Instructores> listaInstructores;
        IEnumerable<Estados> listaEstados;
        private EditContext editContext;

        protected override async Task OnInitializedAsync()
        {
            listaInstructores = await InstructoresDataService.GetAllEntidades();
            listaEstados = await EstadosDataService.GetAllEntidades();

            editContext = new EditContext(Curso);
        }


        public async Task handleSubmmitAsync(Cursos xCurso)
        {
            var isValid = editContext.Validate();

            if (isValid)
            {
                try
                {
                    Cursos addedCurso = await CursoDataService.AddEntidad(xCurso);

                    if (addedCurso.idEntidad != 0)
                    {
                        ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = "Curso agregado exitosamente.", Detail = "Curso Nro: " + addedCurso.idEntidad + ".", Duration = 8000 });
                    }
                    else
                    {
                        ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = "Error del proceso.", Detail = "Curso.", Duration = 8000 });
                    }
                }
                catch 
                {
                    ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = "Error del proceso.", Detail = "Curso.", Duration = 8000 });
                }
                    
                    
            }

            
        }

        public void handleInvalidSubmmit()
        {
            ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = "Validacion!!!.", Detail = "Curso.", Duration = 8000 });
        }

        void ShowNotification(NotificationMessage message)
        {
            
            notificationService.Notify(message);

        }



    }
}
