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

            await _httpClient.PostAsync("api/Cursos/Add", cursoJson);

            return curso;

        }

        public async Task DeleteEntidadById(int cursoId)
        {
            await JsonSerializer.DeserializeAsync<IEnumerable<Cursos>>
                (await _httpClient.GetStreamAsync($"Api/Cursos/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<t>> GetAllEntidades()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<t>>
                (await _httpClient.GetStreamAsync($"Api/Cursos/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetCantEntidad()
        {
            return await JsonSerializer.DeserializeAsync<int>
                (await _httpClient.GetStreamAsync($"Api/Cursos/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<t> GetEntidadById(int cursoId)
        {
            return await JsonSerializer.DeserializeAsync<t>
                (await _httpClient.GetStreamAsync($"Api/Cursos/GetById/{cursoId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateEntidad(t curso)
        {
            var cursoJson =
                new StringContent(JsonSerializer.Serialize(curso), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/Cursos/Update", cursoJson);
        }
    }
}
