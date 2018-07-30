using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.SearchEngine.Bing
{
    class BingResponse
    {
        public string Type { get; set; }
        public WebPages WebPages { get; set; }
    }

    public partial class WebPages
    {
        public string WebSearchUrl { get; set; }
        public string WebSearchUrlPingSuffix { get; set; }
        public long TotalEstimatedMatches { get; set; }
    }
}
