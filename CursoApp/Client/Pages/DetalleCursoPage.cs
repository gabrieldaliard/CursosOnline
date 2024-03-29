﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Components;
using CursoApp.Client.Services;
using Radzen;



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

        [Inject]
        NotificationService notificationService { get; set; }
        [Inject]
        DialogService dialogService { get; set; }

        //IEnumerable<Cursos> curso;
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
                dialogService.OnOpen += Open;
                dialogService.OnClose += Close;
            }


        }

        public Cursos Curso { get; set; } = new Cursos();

        public async Task handleSubmmit()
        {
            try {
                await CursoDataService.UpdateEntidad(Curso);
                ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = "Curso Actulizado exitosamente.", Detail = "Curso Nro: " + Curso.idEntidad + ".", Duration = 8000 });
            }
            catch (Exception ex)
            {
                ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = "Error al actualizar el Curso.", Detail = "Curso Nro: " + Curso.idEntidad + ".", Duration = 8000 });
            }
        }


        public void handleInvalidSubmmit()
        {

        }

        void ShowNotification(NotificationMessage message)
        {
            notificationService.Notify(message);
        }


        private async Task eliminarCursoAsync()
        {
            if ((bool)await dialogService.Confirm("Se eliminará el curso.", "Eliminar", new ConfirmOptions() { OkButtonText = "Aceptar", CancelButtonText = "Cancelar" }))
            {
                await CursoDataService.DeleteEntidadById(Curso.idEntidad);
            }
            
        }

        void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {
            
        }

        void Close(dynamic result)
        {
            
        }


    }
}
