using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CursoApp.Shared.DataBaseModels;

namespace CursoApp.Client.Services
{
    public class InstructorDataService<t> : iEntidadDataService<t> where t : class
    {
        private readonly HttpClient _httpClient;

        public InstructorDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<t> AddEntidad(t obj)
        {
            return await JsonSerializer.DeserializeAsync<t>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Instructor/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task DeleteEntidadById(int xId)
        {
            var response = await _httpClient.DeleteAsync($"api/v1.0/Instructor/DeleteById/{xId}");

            if (response.IsSuccessStatusCode)
            {

            }
        }

        public async Task<IEnumerable<t>> GetAllEntidades()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<t>>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Instructor/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetCantEntidad()
        {
            throw new NotImplementedException();
        }

        public async Task<t> GetEntidadById(int xId)
        {
            return await JsonSerializer.DeserializeAsync<t>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Instructor/GetById/{xId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateEntidad(t obj)
        {
            var cursoJson =
                new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/v1.0/Instructor/Update", cursoJson);
        }
    }
}
