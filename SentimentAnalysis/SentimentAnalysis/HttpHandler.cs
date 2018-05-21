using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SentimentAnalysis
{
    public class HttpHandler
    {
        private string SubscriptionKey = ResourceManager.SubscriptionKey;

        public  HttpClient GetClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
            client.DefaultRequestHeaders.Add("ContentType", "application/json");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }

}
