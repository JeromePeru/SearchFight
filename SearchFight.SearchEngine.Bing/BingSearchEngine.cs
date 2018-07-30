using SearchFight.Contract;
using SearchFight.Shared;
using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Net;

namespace SearchFight.SearchEngine.Bing
{
    [Export(typeof(ISearchEngine))]
    public class BingSearchEngine : ISearchEngine
    {
        public string Name
        {
            get { return "Bing"; }
        }

        public long GetQueryResult(string query)
        {
            try
            {
                string uriQuery = Configuration.ReadSetting("BingURL")
                    .Replace("{QUERY}", Uri.EscapeDataString(query))
                    .Replace("{BingAPI}", Configuration.ReadSetting("BingAPI"))
                    .Replace("{BingCustomConfig}", Configuration.ReadSetting("BingCustomConfig"));

                WebRequest request = WebRequest.Create(uriQuery);
                request.Headers["Ocp-Apim-Subscription-Key"] = Configuration.ReadSetting("BingAPI");
                HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
                string jsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();

                BingResponse bingResponse = Tools.Deserialize<BingResponse>(jsonResponse);
                return bingResponse.WebPages.TotalEstimatedMatches;
            }

            catch (Exception ex)
            {
                throw new SearchEngineException(Name, ex);
            }
        }
    }

}