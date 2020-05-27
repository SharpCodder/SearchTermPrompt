using System;

namespace SearchTermPrompt.Models
{
    public class SearchTermModel
    {
        //This is the actual term show e.g Running Trainer
        public string Term { get; set; }

        //The reason for this property is to speed up the searching
        public string LowercaseTerm { get; set; }

        public int NumberOfSearches { get; set; }
    }
}
