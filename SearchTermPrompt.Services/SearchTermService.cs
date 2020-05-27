using SearchTermPrompt.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchTermPrompt.Services
{
    public class SearchTermService
    {
        private ICacheService _cacheService;

        public SearchTermService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public List<SearchTermModel> GetSearchTerms(string inputTerm = "")
        {
            //Get data from cache
            List<SearchTermModel> models = _cacheService.GetCacheData();

            if (!string.IsNullOrWhiteSpace(inputTerm))
            {
                models = models.Where(t => t.LowercaseTerm.Contains(inputTerm.ToLower())).ToList();
            }

            return models;
        }

        public void LoadSearchTerms()
        {
            List<SearchTermModel> models = new List<SearchTermModel>();
            models.Add(new SearchTermModel()
            {
                Term = "Trail Trainers",
                LowercaseTerm = "trail trainers",
                NumberOfSearches = 150
            });
            models.Add(new SearchTermModel()
            {
                Term = "Road Trainers",
                LowercaseTerm = "road trainers",
                NumberOfSearches = 185
            });
            models.Add(new SearchTermModel()
            {
                Term = "On Trainers",
                LowercaseTerm = "on trainers",
                NumberOfSearches = 64
            });
            models.Add(new SearchTermModel()
            {
                Term = "On Cloudventure",
                LowercaseTerm = "on cloudventure",
                NumberOfSearches = 15
            });
            models.Add(new SearchTermModel()
            {
                Term = "On Cloudventure Peaks",
                LowercaseTerm = "on cloudventure peaks",
                NumberOfSearches = 12
            });
            models.Add(new SearchTermModel()
            {
                Term = "On Cloudsurfer",
                LowercaseTerm = "on cloudsurfer",
                NumberOfSearches = 23
            });
            models.Add(new SearchTermModel()
            {
                Term = "On Cloudflow",
                LowercaseTerm = "on cloudflow",
                NumberOfSearches = 22
            });
            models.Add(new SearchTermModel()
            {
                Term = "Salamon Speedcross",
                LowercaseTerm = "salamon speedcross",
                NumberOfSearches = 34
            });
            models.Add(new SearchTermModel()
            {
                Term = "On",
                LowercaseTerm = "on",
                NumberOfSearches = 156
            });
            models.Add(new SearchTermModel()
            {
                Term = "Salamon",
                LowercaseTerm = "salamon",
                NumberOfSearches = 345
            });
            models.Add(new SearchTermModel()
            {
                Term = "Salamon Speedcross 4",
                LowercaseTerm = "salamon speedcross 4",
                NumberOfSearches = 187
            });
            _cacheService.LoadCacheData(models.OrderByDescending(m => m.NumberOfSearches).ToList());
        }
    }
}
