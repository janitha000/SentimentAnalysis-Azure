using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SentimentAnalysis
{
    public class HttpHandler
    {
        private const string SubscriptionKey = "dd0e293190144f3082e98b8782000450";

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
