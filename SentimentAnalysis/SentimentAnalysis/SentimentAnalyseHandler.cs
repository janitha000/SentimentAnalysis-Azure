using Newtonsoft.Json;
using SentimentAnalysis.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SentimentAnalysis
{
    public class SentimentAnalyseHandler
    {
        private const string ApiUri = "https://eastus2.api.cognitive.microsoft.com/text/analytics/v2.0";
        private const string SubscriptionKey = "dd0e293190144f3082e98b8782000450";
        private static readonly HttpClient Client = GetClient();

        public  TextAnalyticsResponse GetSentiment(string text)
        {
            var body = JsonConvert.SerializeObject(new
            {
                Documents = new object[]
                {
                    new { Text = text, Id = Guid.NewGuid() }
                }
            });

            using (var content = new ByteArrayContent(Encoding.UTF8.GetBytes(body)))
            {
                var responseMessage = Client.PostAsync($"{ApiUri}/sentiment", content).Result;
                responseMessage.EnsureSuccessStatusCode();
                var json = responseMessage.Content.ReadAsStringAsync().Result;
                return DeserializeTextAnalyticsResponse(json);
            }
        }

        private static HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        private static TextAnalyticsResponse DeserializeTextAnalyticsResponse(string json)
        {
            return JsonConvert.DeserializeObject<TextAnalyticsResponse>(json);
        }
    }
}
