using System.Collections.Generic;
using System;
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
        public iEntidadDataService<Cursos> CursoDataService { get; set; }
        [Inject]
        DialogService dialogService { get; set; }
        [Inject]
        NotificationService notificationService { get; set; }
        [Inject]
        public iEntidadDataService<Estados> EstadosDataService { get; set; }

        IEnumerable<Cursos> xCurso;
        IEnumerable<Estados> listaEstados;


        protected override async Task OnInitializedAsync()
        {            
            xCurso = await CursoDataService.GetAllEntidades();
            listaEstados = await EstadosDataService.GetAllEntidades();

            dialogService.OnOpen += Open;
            dialogService.OnClose += Close;
        }

        public void clickFila(CursoApp.Shared.DataBaseModels.Cursos row)
        {
            NavManager.NavigateTo("DetalleCursoPage/" + row.idEntidad);
        }

        //public async Task DeleteRowAsync(CursoApp.Shared.DataBaseModels.Cursos curso)
        //{
        //    var confirmResult = await dialogService.Confirm("Se eliminará el curso: " + curso.Titulo, "Eliminar", new ConfirmOptions() { OkButtonText = "Aceptar", CancelButtonText = "Cancelar" });
        //    if (confirmResult.HasValue && confirmResult.Value)
        //    {
        //        try
        //        {
        //            await CursoDataService.DeleteEntidadById(curso.idEntidad);
        //            ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Success, Summary = "Curso eliminado exitosamente.", Detail = "Curso Nro: " + curso.idEntidad + ".", Duration = 8000 });
        //            await gridCursos.Reload();
        //        }
        //        catch (Exception ex)
        //        {
        //            ShowNotification(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = "Error al eliminar el Curso.", Detail = "Curso Nro: " + curso.idEntidad + ".", Duration = 8000 });
        //        }               
        //    }
        //}

        void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {

        }

        void Close(dynamic result)
        {

        }

        public void Dispose()
        {
            // The DialogService is a singleton so it is advisable to unsubscribe.
            dialogService.OnOpen -= Open;
            dialogService.OnClose -= Close;
        }

        void ShowNotification(NotificationMessage message)
        {
            notificationService.Notify(message);
        }





    }

}
