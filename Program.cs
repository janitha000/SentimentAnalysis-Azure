using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

public class Program
{
  private const string ApiUri = "https://eastus2.api.cognitive.microsoft.com/text/analytics/v2.0";
  private const string SubscriptionKey = "dd0e293190144f3082e98b8782000450";
  private const string Text = "The food was delicious and there were wonderful staff.";
  private static readonly HttpClient Client = GetClient();

  static void Main(string[] args)
  {
    Console.WriteLine("Starting Analyzer, enter the text");
    string text = Console.Read();
    Console.WriteLine($"Starting sentiment analysis from: {Text}");

    // Get Sentiment

    Console.WriteLine($"Ending sentiment analysis");
  }

  // GetSentiment Method

  private static HttpClient GetClient()
  {
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);
    client.DefaultRequestHeaders.Add("ContentType", "application/json");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    return client;
  }

  private class Document
  {
    public string Id { get; set; }
    public double? Score { get; set; }
  }

  private class TextAnalyticsResponse
  {
    public List<Document> Documents { get; set; }
  }

  private static TextAnalyticsResponse DeserializeTextAnalyticsResponse(string json)
  {
    return JsonConvert.DeserializeObject<TextAnalyticsResponse>(json);
  }
}
