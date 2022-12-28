using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using CursoApp.Shared.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Text;
using CursoApp.Client.Services;

namespace usuarioApp.Client.Services{
    public class UsuarioDataService<t> : iEntidadDataService<t> where t : class
    {

        private readonly HttpClient _httpClient;

        public UsuarioDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<t> AddEntidad(t usuario)
        {
            var usuarioJson =
                new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/v1.0/Usuarios/Add", usuarioJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<t>(await response.Content.ReadAsStreamAsync());
            }

            return null;

        }

        public async Task DeleteEntidadById(int usuarioId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1.0/usuarios/DeleteById/{usuarioId}");

            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task<IEnumerable<t>> GetAllEntidades()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<t>>
                (await _httpClient.GetStreamAsync($"Api/v1.0/usuarios/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetCantEntidad()
        {
            return await JsonSerializer.DeserializeAsync<int>
                (await _httpClient.GetStreamAsync($"Api/v1.0/usuarios/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<t> GetEntidadById(int usuarioId)
        {
            return await JsonSerializer.DeserializeAsync<t>
                (await _httpClient.GetStreamAsync($"Api/v1.0/usuarios/GetById/{usuarioId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateEntidad(t usuario)
        {
            var usuarioJson =
                new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/v1.0/usuarios/Update", usuarioJson);
        }


    }
}
