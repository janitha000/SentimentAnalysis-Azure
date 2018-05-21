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
        public static LanguageDetectionHandler languageDetectionHandler = new LanguageDetectionHandler();


        static void Main(string[] args)
        {
            Console.WriteLine("Starting Analyzer, enter 1 for Sentiment Analyzer, 2 for LanguageDetector");
            int Text =Int32.Parse( Console.ReadLine());

            switch (Text)
            {
                case 1:
                    SentimentAnalyse();
                    break;
                case 2:
                    LanguageDetection();
                    break;
                default:
                    break;
                    
            }
            




        }

        private static void SentimentAnalyse() 
        {
            Console.WriteLine("Starting Analyzer, enter text");
            string Text = Console.ReadLine(); 
            Console.WriteLine($"Starting sentiment analysis from: {Text}");

            var sentimentResponse = sentimentAnalyseHandler.GetSentiment(Text);
            Console.WriteLine($"Detected sentiment score: {sentimentResponse.Documents.FirstOrDefault().Score}");
            var sentiment = sentimentResponse.Documents.FirstOrDefault().Score > 0.5 ? "Positive" : "Negative";
            Console.WriteLine($"Detected sentiment: { sentiment }");

            Console.WriteLine($"Ending sentiment analysis");
        }

        private static void LanguageDetection()
        {
            Console.WriteLine("Starting detector, enter text");
            string Text = Console.ReadLine();
            Console.WriteLine($"Starting language detection from: {Text}");

            var languages = languageDetectionHandler.GetLanguage(Text);
            foreach (var language in languages)
            {
                Console.WriteLine($"Detected Language: {language.Name}");
                Console.WriteLine($"Confidence Score: {language.Score}");
            }
        }









    }
}
