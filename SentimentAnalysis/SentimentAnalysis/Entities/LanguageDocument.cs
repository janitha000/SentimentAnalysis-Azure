using System;
using System.Collections.Generic;
using System.Text;

namespace SentimentAnalysis.Entities
{
    public class LanguageDocument
    {
        public string Id { get; set; }
        public List<Language> DetectedLanguages { get; set; }
    }
}
