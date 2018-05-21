using Newtonsoft.Json;
using SentimentAnalysis.Entities;
using SentimentAnalysis.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SentimentAnalysis
{
    public class LanguageDetectionHandler
    {
        HttpHandler httpHandler = new HttpHandler();

        public  List<Language> GetLanguage(string text)
        {
            HttpClient Client = httpHandler.GetClient();

            var body = JsonConvert.SerializeObject(new
            {
                Documents = new TextToAnalyse[]
                    {
                    new TextToAnalyse {Text = text, Id = Guid.NewGuid()
                    }
                }
            });
            using (var content = new ByteArrayContent(Encoding.UTF8.GetBytes(body)))
            {
                var responseMessage = Client.PostAsync($"{ResourceManager.ApiUrl}/languages", content).Result;
                responseMessage.EnsureSuccessStatusCode();
                var json = responseMessage.Content.ReadAsStringAsync().Result;
                var analyticsResponse = DeserializeTextAnalyticsResponse(json);
                return analyticsResponse.Documents.FirstOrDefault()?.DetectedLanguages;
            }
        }

        private static TextAnalyticResponseLanguage DeserializeTextAnalyticsResponse(string json)
        {
            return JsonConvert.DeserializeObject<TextAnalyticResponseLanguage>(json);
        }
    }
}
