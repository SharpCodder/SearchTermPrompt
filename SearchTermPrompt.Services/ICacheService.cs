using SearchTermPrompt.Models;
using System.Collections.Generic;

namespace SearchTermPrompt.Services
{
    public interface ICacheService
    {
        List<SearchTermModel> GetCacheData();
        bool LoadCacheData(List<SearchTermModel> models);
    }
}