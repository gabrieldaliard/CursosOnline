using CursoApp.Shared.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using System.Text;

namespace CursoApp.Client.Services
{
    public class CursosDataService<t> : iEntidadDataService<t> where t : class
    {
        private readonly HttpClient _httpClient;

        public CursosDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<t> AddEntidad(t curso)
        {
            var cursoJson =
                new StringContent(JsonSerializer.Serialize(curso), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/v1.0/Cursos/Add", cursoJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<t>(await response.Content.ReadAsStreamAsync());
            }

            return null;

        }

        public async Task DeleteEntidadById(int cursoId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1.0/Cursos/DeleteById/{cursoId}" );

            if (response.IsSuccessStatusCode)
            {

            }

        }

        public async Task<IEnumerable<t>> GetAllEntidades()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<t>>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Cursos/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetCantEntidad()
        {
            return await JsonSerializer.DeserializeAsync<int>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Cursos/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<t> GetEntidadById(int cursoId)
        {
            return await JsonSerializer.DeserializeAsync<t>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Cursos/GetById/{cursoId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateEntidad(t curso)
        {
            var cursoJson =
                new StringContent(JsonSerializer.Serialize(curso), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/v1.0/Cursos/Update", cursoJson);
        }
    }
}
