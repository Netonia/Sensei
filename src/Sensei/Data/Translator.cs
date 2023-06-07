using System.Text;
using Sensei.Models;
using Newtonsoft.Json;

namespace Sensei.Data;

public class Translator
{
    private static readonly string subscriptionKey = "fa3408b0876248069acac617cf6b4b4f";
    private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";
    private static readonly string location = "francecentral";

    public static async Task<string> TranslateAsync(string textToTranslate, string from, string to)
    {
        string result = string.Empty;

        if (!string.IsNullOrEmpty(textToTranslate))
        {
            string route = $"/translate?api-version=3.0&from={from}&to={to}";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync();
                var translations = JsonConvert.DeserializeObject<ApiTranslation[]>(json);

                if (translations != null && translations.Any())
                {
                    if (translations[0].Translations.Any())
                    {
                        result = translations[0].Translations[0].Text;
                    }
                }
            }
        }
        else
        {
            result = "Specify a text to translate.";
        }

        return result;
    }

    public static async Task<string> TransliterationAsync(string textToTranslate, string fromScript, string toScript)
    {
        string result = string.Empty;

        if (!string.IsNullOrEmpty(textToTranslate))
        {
            string route = $"/transliterate?api-version=3.0&language=ja&fromScript={fromScript}&toScript={toScript}";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync();
                var transliterations = JsonConvert.DeserializeObject<Transliteration[]>(json);

                if (transliterations != null && transliterations.Any())
                {
                    result = transliterations[0].Text;
                }
            }
        }

        return result;
    }
}