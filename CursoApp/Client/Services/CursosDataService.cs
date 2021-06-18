using CursoApp.Shared.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace CursoApp.Client.Services
{
    public class CursosDataService : iCursosDataService
    {
        private readonly HttpClient _httpClient;

        public CursosDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Cursos AddCurso(Cursos curso)
        {
            throw new NotImplementedException();
        }

        public void DeleteCursoById(int cursoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cursos>> GetAllCursos()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Cursos>>
                (await _httpClient.GetStreamAsync($"Api/GetAllCursos"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

        public Task<int> GetCantCurso()
        {
            throw new NotImplementedException();
        }

        public Cursos GetCursoById(int cursoId)
        {
            throw new NotImplementedException();
        }

        public Cursos UpdateCurso(Cursos curso)
        {
            throw new NotImplementedException();
        }
    }
}
