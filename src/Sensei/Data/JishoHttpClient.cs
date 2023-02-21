using JishoNET.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Sensei.Data;

public class JishoHttpClient
{
    private readonly HttpClient http;

    public JishoHttpClient(HttpClient http)
    {
        this.http = http;
    }

    private static readonly string baseUrl = new("https://jisho.org/api/v1/search/words?keyword=");

    public async Task<JishoResult<JishoDefinition[]>> GetDefinitionAsync(string keyword)
    {
        try
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage { RequestUri = new Uri(baseUrl + keyword), Method = HttpMethod.Get };
            httpRequestMessage.SetBrowserRequestMode(BrowserRequestMode.NoCors);
            HttpResponseMessage response = await client.SendAsync(httpRequestMessage); //client.GetAsync(baseUrl + keyword);
            var stringResponse = await response.Content.ReadAsStringAsync();
            //JishoResult<JishoDefinition[]> result = await client.GetFromJsonAsync<JishoResult<JishoDefinition[]>>(baseUrl + keyword);
            JishoResult<JishoDefinition[]> result = JsonSerializer.Deserialize<JishoResult<JishoDefinition[]>>(stringResponse);
            result.Meta.Status = ((int)response.StatusCode);
            result.Success = true;
            return result;
        }
        catch (Exception e)
        {
            return new JishoResult<JishoDefinition[]>
            {
                Success = false,
                Exception = e.ToString()
            };
        }
    }
}