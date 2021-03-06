﻿using Newtonsoft.Json;
using SentimentAnalysis.Entities;
using SentimentAnalysis.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SentimentAnalysis
{
    public class SentimentAnalyseHandler
    {
        HttpHandler httpHandler = new HttpHandler();

        public TextAnalyticResponseSentiment GetSentiment(string text)
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



        private static TextAnalyticResponseSentiment DeserializeTextAnalyticsResponse(string json)
        {
            return JsonConvert.DeserializeObject<TextAnalyticResponseSentiment>(json);
        }
    }
}
