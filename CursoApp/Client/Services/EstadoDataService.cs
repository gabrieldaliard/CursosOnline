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
    public class EstadoDataService<t> : iEntidadDataService<t> where t : class
    {
        private readonly HttpClient _httpClient;

        public EstadoDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<t> AddEntidad(t obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEntidadById(int xId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<t>> GetAllEntidades()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<t>>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Estados/GetAll"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task<int> GetCantEntidad()
        {
            throw new NotImplementedException();
        }

        public async Task<t> GetEntidadById(int xId)
        {
            return await JsonSerializer.DeserializeAsync<t>
                (await _httpClient.GetStreamAsync($"Api/v1.0/Estados/GetById/{xId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateEntidad(t obj)
        {
            throw new NotImplementedException();
        }
    }
}
