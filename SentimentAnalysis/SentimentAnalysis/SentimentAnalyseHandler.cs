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
        HttpHandler httpHandler = new HttpHandler();

        public TextAnalyticsResponse GetSentiment(string text)
        {
            HttpClient Client = httpHandler.GetClient();
            var body = JsonConvert.SerializeObject(new
            {
                Documents = new object[]
                    {
                    new { Text = text, Id = Guid.NewGuid() }
                    }
            });

            using (var content = new ByteArrayContent(Encoding.UTF8.GetBytes(body)))
            {
                var responseMessage = Client.PostAsync($"{ResourceManager.ApiUrl}/sentiment", content).Result;
                responseMessage.EnsureSuccessStatusCode();
                var json = responseMessage.Content.ReadAsStringAsync().Result;
                return DeserializeTextAnalyticsResponse(json);
            }
        }



        private static TextAnalyticsResponse DeserializeTextAnalyticsResponse(string json)
        {
            return JsonConvert.DeserializeObject<TextAnalyticsResponse>(json);
        }
    }
}
