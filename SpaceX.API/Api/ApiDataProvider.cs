using Newtonsoft.Json;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpaceX.DTO.ApiModels.ApiModel;

namespace SpaceX.API.Api;
public class ApiDataProvider : IApiDataProvider
{
    private readonly HttpClient _httpClient;

    public ApiDataProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiDataProvider");
    }

    public async Task<List<Root>> CallApi(string endpoint)
    {
        // Perform HTTP request:
        HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            // Convert HTTP response to JSON-string (reading the content of the body):
            var responseString = await response.Content.ReadAsStringAsync();

            // Convert JSON-string to C#-object:
            List<Root> result = JsonConvert.DeserializeObject<List<Root>>(responseString);

            return result;
        }

            return new List<Root>();
    }
}
