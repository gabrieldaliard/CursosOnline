using CursoApp.Client.Services;
using CursoApp.Shared.DataBaseModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace CursoApp.Client.Pages
{
    public partial class UsuariosPage
    {
        [Inject]
        public iEntidadDataService<Usuarios> UsuarioDataService { get; set; }
        [Inject]
        DialogService dialogService { get; set; }
        [Inject]
        NotificationService notificationService { get; set; }
        [Inject]
        public iEntidadDataService<Estados> EstadosDataService { get; set; }
        NavigationManager NavManager;

        IEnumerable<Usuarios> xUsuario;
        IEnumerable<Estados> listaEstados;

        protected override async Task OnInitializedAsync()
        {
            xUsuario = await UsuarioDataService.GetAllEntidades();
            listaEstados = await EstadosDataService.GetAllEntidades();

            dialogService.OnOpen += Open;
            dialogService.OnClose += Close;
        }

        public void clickFila(CursoApp.Shared.DataBaseModels.Usuarios row)
        {
            NavManager.NavigateTo("DetalleUsuariosPage/" + row.idEntidad);
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

        void Open(string title, Type type, Dictionary<string, object> parameters, DialogOptions options)
        {

        }

        void Close(dynamic result)
        {

        }


    }


}
