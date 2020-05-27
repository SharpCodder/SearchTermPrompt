using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchTermPrompt.Services;

namespace SearchTermPrompt.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchTermController : ControllerBase
    {
        public IActionResult Get(string input)
        {
            SearchTermService service = new SearchTermService(new SystemCacheService());
            return Ok(service.GetSearchTerms(input)
                .Take(10).Select(t=>
                    "<a style=\"display:inline-block;width:100%;\" href=\"search-results\\" 
                        + t.LowercaseTerm + "\">" + t.Term + "</a>"));
        }

        [HttpPost]
        public IActionResult LoadData()
        {
            SearchTermService service = new SearchTermService(new SystemCacheService());
            service.LoadSearchTerms();
            return Ok();
        }
    }
}