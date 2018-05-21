using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SentimentAnalysis
{
    class Program
    {
        public static SentimentAnalyseHandler sentimentAnalyseHandler = new SentimentAnalyseHandler();

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Analyzer, enter the text");
            string Text = Console.ReadLine();
            Console.WriteLine($"Starting sentiment analysis from: {Text}");

            var sentimentResponse = sentimentAnalyseHandler.GetSentiment(Text);
            Console.WriteLine($"Detected sentiment score: {sentimentResponse.Documents.FirstOrDefault().Score}");
            var sentiment = sentimentResponse.Documents.FirstOrDefault().Score > 0.5 ? "Positive" : "Negative";
            Console.WriteLine($"Detected sentiment: { sentiment }");

            Console.WriteLine($"Ending sentiment analysis");
        }









    }
}
