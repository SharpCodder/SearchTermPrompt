using SearchTermPrompt.Models;
using ServiceStack.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchTermPrompt.Services
{
    public class RedisCacheService : ICacheService
    {
        RedisEndpoint _endPoint;
        public List<SearchTermModel> GetCacheData()
        {
            List<SearchTermModel> models;
            using(RedisClient client = new RedisClient(_endPoint))
            {
                if (IsInCache("SearchTerms"))
                    models = client.Get<List<SearchTermModel>>("SearchTerms");
                else
                    models = new List<SearchTermModel>();
            }

            return models;
        }

        public bool LoadCacheData(List<SearchTermModel> models)
        {
            using(RedisClient client = new RedisClient(_endPoint))
            {
                client.Set<List<SearchTermModel>>("SearchTerms", models);
                return IsInCache("SearchTerms");
            }
        }

        public bool IsInCache(string key)
        {
            bool isInCache = false;

            using (RedisClient client = new RedisClient(_endPoint))
            {
                isInCache = client.ContainsKey(key);
            }

            return isInCache;
        }
    }
}
