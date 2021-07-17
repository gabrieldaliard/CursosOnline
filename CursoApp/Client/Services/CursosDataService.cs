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
    public class CursosDataService : iCursosDataService
    {
        private readonly HttpClient _httpClient;

        public CursosDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Cursos> AddCurso(Cursos curso)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCursoById(int cursoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cursos>> GetAllCursos()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Cursos>>
                (await _httpClient.GetStreamAsync($"Api/GetAllCursos"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetCantCurso()
        {
            throw new NotImplementedException();
        }

        public async Task<Cursos> GetCursoById(int cursoId)
        {
            return await JsonSerializer.DeserializeAsync<Cursos>
                (await _httpClient.GetStreamAsync($"Api/GetCursoById/{cursoId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateCurso(Cursos curso)
        {
            var cursoJson =
                new StringContent(JsonSerializer.Serialize(curso), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/UpdateCurso", cursoJson);
        }
    }
}
