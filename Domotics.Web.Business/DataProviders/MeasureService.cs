namespace Domotics.Web.Business.DataProviders
{
    using Domotics.Web.Business.DataProviders.Abstractions;
    using Domotics.Web.Business.DataProviders.Dtos;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Text.Json;

    internal sealed class MeasureService : IMeasureService
    {
        private readonly HttpClient httpClient;

        public MeasureService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<MeasureDto>> GetAllAsync()
        {
            var responseString = await this.httpClient.GetStringAsync("/api/measures");

            return JsonSerializer.Deserialize<List<MeasureDto>>(responseString, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}
