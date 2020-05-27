using Microsoft.Extensions.Caching.Memory;
using SearchTermPrompt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchTermPrompt.Services
{
    public class SystemCacheService : ICacheService
    {
        private static MemoryCache _cache;
        
        public MemoryCache MemoryCache
        {
            get
            {
                if (_cache == null)
                    _cache = new MemoryCache(new MemoryCacheOptions());

                return _cache;
            }
        }

    public List<SearchTermModel> GetCacheData()
        {
            List<SearchTermModel> models;
            if (!MemoryCache.TryGetValue("SearchTerms", out models))
                return models = new List<SearchTermModel>();

            return models;
        }

        public bool LoadCacheData(List<SearchTermModel> models)
        {
            MemoryCache.Set("SearchTerms", models);
            return MemoryCache.TryGetValue("SearchTerms", out models);
        }
    }
}
